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
									"1984",
									"George Orwell",
									"Published in 1949, the book offers political satirist George Orwell's nightmarish vision of a totalitarian, bureaucratic world and one poor stiff's attempt to find individuality",
									"4.19",
									"Yes! This book! Amazing! Terrifying, brutal, intricate, prophetic - and, in one big word, GENIUS!"));

			bookReviews.Add(PrepareBookObject("3",
									"The Great Gatsby",
									"F. Scott Fitzgerald",
									"The story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan, of lavish parties on Long Island at a time when The New York Times noted 'gin was the national drink and sex the national obsession,' it is an exquisitely crafted tale of America in the 1920s",
									"3.93",
									"Fitzgerald can set a scene so perfectly, flawlessly. He paints a world of magic and introduces one of the greatest characters of all time, Jay Gatsby. Gatsby is the embodiment of hope, and no one can dissuade him from his dreams"));

			bookReviews.Add(PrepareBookObject("4",
												"Harry Potter and the Sorcerer's Stone",
												"J.K. Rowling",
												"Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright",
												"4.47",
												"As wonderful and magical as promised. Because I didn't remember the movie, the third act of the book was a delightful surprise to me"));

			bookReviews.Add(PrepareBookObject("5",
												"The Little Prince",
												"Antoine de Saint-Exupéry",
												"A pilot stranded in the desert awakes one morning to see, standing before him, the most extraordinary little fellow. 'Please,' asks the stranger, 'draw me a sheep.' And the pilot realizes that when life's events are too difficult to understand, there is no choice but to succumb to their mysteries. He pulls out pencil and paper... And thus begins this wise and enchanting fable that, in teaching the secret of what is really important in life, has changed forever the world for its readers",
												"4.32",
												"We are all children in adult bodies. Yes we are, don't think we aren't for one moment. The fact that we WERE, indeed, children, is a huge part of each of us. It is possible to shed a few appreciative tears on every page of this book if you entertain the thought that the pilot IS The Little Prince"));

			bookReviews.Add(PrepareBookObject("6",
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
