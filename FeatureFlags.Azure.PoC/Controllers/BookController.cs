using FeatureFlags.Azure.PoC.Models;
using FeatureFlags.Azure.PoC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlags.Azure.PoC.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		private readonly IBookDataService _bookDataService;

		public BookController(IBookDataService bookDataService)
		{
			_bookDataService = bookDataService;
		}

        [FeatureGate(nameof(Models.Enums.FeatureFlags.TargetUsers))]
        public IActionResult Index()
        {
            List<Book> books = _bookDataService.GetAllBookReviews();
            return View(books);
        }

        [FeatureGate(nameof(Models.Enums.FeatureFlags.BookDetailReview))]
        [FeatureGate(nameof(Models.Enums.FeatureFlags.BrowserFilter))]
        [FeatureGate(nameof(Models.Enums.FeatureFlags.TargetUsers))]
        public IActionResult ReviewDetails(string? id)
        {
            Book? book = _bookDataService.GetAllBookReviews().Find(p => p.Id.Equals(id));
            return View(book);
        }
    }
}
