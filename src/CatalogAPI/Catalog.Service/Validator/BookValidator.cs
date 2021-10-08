using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Service.Entity;
using FluentValidation;

namespace Catalog.Service.Validator
{
    internal sealed class BookValidator : AbstractValidator<Book>
    {
        internal BookValidator()
        {
            RuleFor(p => p.BookName)
                .NotEmpty().WithMessage("Book Name not informed");

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
