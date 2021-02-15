namespace Bookshop.Api.Models
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int? ShowcaseId { get; set; }
    }
}