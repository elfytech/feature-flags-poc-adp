using Microsoft.FeatureManagement;

namespace FeatureFlags.Azure.PoC.Filters
{
	[FilterAlias(nameof(Models.Enums.FeatureFlags.BrowserFilter))]
	public class BrowserFilter : IFeatureFilter
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public BrowserFilter(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
		{
			var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
			var settings = context.Parameters.Get<BrowserFilterSettings>();
			return Task.FromResult(settings.AllowedBrowsers.Any(userAgent.Contains));
		}
	}
}
