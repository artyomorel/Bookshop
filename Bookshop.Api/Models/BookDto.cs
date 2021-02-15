namespace Bookshop.Api.Models
{
    public class BookDto
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int? ShowcaseId { get; set; }
    }
}