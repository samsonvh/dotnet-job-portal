using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyCollection<ValidationError> Errors { get; set; }

        public ValidationException(string message, IReadOnlyCollection<ValidationError> errors) : base(message)
        {
            Errors = errors;
        }
    }

    public record ValidationError(string PropertyName, string ErrorMessage);
}
