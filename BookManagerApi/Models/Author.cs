namespace BookManagerApi.Models
{
    public class Author : IObjectHasId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }

        public List<Book> Books { get; set; }
    }
}
