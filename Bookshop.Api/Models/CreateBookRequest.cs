using FluentValidation;

namespace Bookshop.Api.Models
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int? ShowcaseId { get; set; }
    }


    public class CreateBookRequestValidation: AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Size).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.ShowcaseId).GreaterThan(0);
        }
    }
}