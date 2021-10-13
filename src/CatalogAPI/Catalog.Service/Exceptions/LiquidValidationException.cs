using System.Collections.Generic;
using FluentValidation.Results;
using Liquid.Core.Exceptions;

namespace Catalog.Service.Exceptions
{
    public sealed class LiquidValidationException : LiquidException
    {
        public List<string> ValdationErrors { get; set; }

        public LiquidValidationException(ValidationResult validationResult)
            : base()
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
