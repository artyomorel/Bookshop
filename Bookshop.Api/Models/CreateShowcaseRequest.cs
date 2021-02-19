using System;
using FluentValidation;

namespace Bookshop.Api.Models
{
    public class CreateShowcaseRequest
    {
        public string Name { get; set; }
        public int TotalSize { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }

    public class CreateShowcaseRequestValidator : AbstractValidator<CreateShowcaseRequest>
    {
        public CreateShowcaseRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.TotalSize).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.CreateTime).LessThan(DateTime.Now).NotEmpty().NotNull();
            RuleFor(x => x.DeleteTime).GreaterThan(x => x.CreateTime).LessThan(DateTime.Now);
        }
    }
}