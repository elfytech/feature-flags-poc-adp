using FeatureFlags.Azure.PoC.Models;
using FeatureFlags.Azure.PoC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlags.Azure.PoC.Controllers
{
    [Authorize]
	public class BookController : Controller
	{
		private readonly IBookDataService _bookDataService;
        private readonly IFeatureManager _featureManager;

		public BookController(IBookDataService bookDataService, IFeatureManager featureManager)
		{
			_bookDataService = bookDataService;
            _featureManager = featureManager;
		}

		[FeatureGate(Constants.FeatureFlags.TargetUsers)]
        public IActionResult Index()
        {
            List<Book> books = _bookDataService.GetAllBookReviews();
            return View(books);
        }

        [FeatureGate(Constants.FeatureFlags.BookDetailReview)]
        [FeatureGate(Constants.FeatureFlags.BrowserFilter)]
        [FeatureGate(Constants.FeatureFlags.TargetUsers)]
        public IActionResult ReviewDetails(string? id)
        {
            Book? book = _bookDataService.GetAllBookReviews().Find(p => p.Id.Equals(id));
            return View(book);
        }
    }
}
