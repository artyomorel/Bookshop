using FluentValidation;

namespace Bookshop.Api.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int? ShowcaseId { get; set; }
    }
    public class BookDtoValidation: AbstractValidator<BookDto>
    {
        public BookDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Size).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.ShowcaseId).GreaterThan(0);
            RuleFor(x => x.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}