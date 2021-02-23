using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshop.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public int? ShowcaseId { get; set; }
    }
}