using FeatureFlags.Azure.PoC.Models;

namespace FeatureFlags.Azure.PoC.Repositories
{
	public class MockBookDataService : IBookDataService
	{
		public List<Book> GetAllBookReviews()
		{
			List<Book> bookReviews = new();
			bookReviews.Add(PrepareBookObject("1",
												"To Kill a Mockingbird",
												"Harper Lee",
												"The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it",
												"4.27",
												"To Kill a Mockingbird one of the best-loved stories of all time, is a novel by Harper Lee published in 1960"));
			bookReviews.Add(PrepareBookObject("2",
												"Harry Potter and the Sorcerer's Stone",
												"J.K. Rowling",
												"Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright",
												"4.47",
												"As wonderful and magical as promised. Because I didn't remember the movie, the third act of the book was a delightful surprise to me"));
			bookReviews.Add(PrepareBookObject("3",
												"Pride and Prejudice",
												"Jane Austen",
												"Since its immediate success in 1813, Pride and Prejudice has remained one of the most popular novels in the English language. The romantic clash between the opinionated Elizabeth and her proud beau, Mr. Darcy, is a splendid performance of civilized sparring",
												"4.28",
												"Pride and Prejudice by Jane Austen started off annoying me and ended up enchanting me. Up until about page one hundred I found this book vexing, frivolous and down right tedious. I now count myself as a convert to the Austen cult"));

			return bookReviews;
		}

		private Book PrepareBookObject(string id, string title, string author, string description, string rating, string remarks)
		{
			return new Book
			{
				Id = id,
				Title = title,
				Author = author,
				Description = description,
				ReviewDetails = new BookReview
				{
					Rating = rating,
					Remarks = remarks
				}
			};
		}
	}
}
