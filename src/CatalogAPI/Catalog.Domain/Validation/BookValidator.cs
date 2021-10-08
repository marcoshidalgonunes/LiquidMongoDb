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

        }
    }
}
