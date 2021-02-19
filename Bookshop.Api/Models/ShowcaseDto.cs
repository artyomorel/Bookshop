using System;
using FluentValidation;

namespace Bookshop.Api.Models
{
    public class ShowcaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSize { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
    
    public class ShowcaseDtoValidation: AbstractValidator<ShowcaseDto>
    {
        public ShowcaseDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.TotalSize).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.CreateTime).LessThan(DateTime.Now).NotEmpty().NotNull();
            RuleFor(x => x.DeleteTime).GreaterThan(x => x.CreateTime).LessThan(DateTime.Now);
        }
    }
}