using FeatureFlags.Azure.PoC.Data;
using FeatureFlags.Azure.PoC.Filters;
using FeatureFlags.Azure.PoC.Handlers;
using FeatureFlags.Azure.PoC.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using Azure.Identity;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

builder.Host.ConfigureAppConfiguration((config, appBuilder) =>
{
	var settings = appBuilder.Build();

	appBuilder.AddAzureAppConfiguration(azureConfig =>
	{
		azureConfig
			.Connect(settings["AppConfig"])
			.ConfigureKeyVault(kv =>
			{
				kv.SetCredential(new DefaultAzureCredential());
			})
			// include all settings without a label
			.Select(KeyFilter.Any, LabelFilter.Null)
			// include all settings with the label that corresponds to the current environment
			// this overrides the previous setting if there are any
			.Select(KeyFilter.Any, config.HostingEnvironment.EnvironmentName);
		azureConfig.UseFeatureFlags();
	});
});

builder.Services.AddAzureAppConfiguration();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IBookDataService, MockBookDataService>();

builder.Services.AddFeatureManagement()
				.UseDisabledFeaturesHandler(new CustomDisabledFeatureHandler())
				.AddFeatureFilter<TimeWindowFilter>()
				.AddFeatureFilter<TargetingFilter>()
				.AddFeatureFilter<BrowserFilter>();

builder.Services.AddSingleton<ITargetingContextAccessor, TargetingContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseAzureAppConfiguration();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
