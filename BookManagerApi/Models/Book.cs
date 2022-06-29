namespace BookManagerApi.Models
{
	public class Book : IObjectHasId
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Author Author { get; set; }
		public Genre Genre { get; set; }
	}
}
