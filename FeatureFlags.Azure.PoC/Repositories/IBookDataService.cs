using FeatureFlags.Azure.PoC.Models;

namespace FeatureFlags.Azure.PoC.Repositories
{
	public interface IBookDataService
	{
		List<Book> GetAllBookReviews();
	}
}
