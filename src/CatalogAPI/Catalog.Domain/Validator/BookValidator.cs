using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using FluentValidation;

namespace Catalog.Domain.Validation
{
    public sealed class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name not informed");

            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("Author not informed");

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category not informed");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price not informed")
                .GreaterThan(0).WithMessage("Invalid price");

        }
    }
}
