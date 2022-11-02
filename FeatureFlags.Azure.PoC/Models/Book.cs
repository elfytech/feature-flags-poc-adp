namespace FeatureFlags.Azure.PoC.Models
{
	public class Book
	{
		public string? Id { get; set; }
		public string? Title { get; set; }
		public string? Author { get; set; }
		public string? Description { get; set; }
		public BookReview? ReviewDetails { get; set; }
	}
}
