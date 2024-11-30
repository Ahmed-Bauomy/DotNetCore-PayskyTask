using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        private List<string> Errors { get; init; } = new List<string>();
        public CustomValidationException()
            :base("one or more validation errors have occurred.")
        { }

        public CustomValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures.Select(f => f.PropertyName +": " + f.ErrorMessage).ToList();
        }

        public override string ToString()
        {
            var error = Message + "\n";
            error += string.Join("\n", Errors);
            error += "\n" + base.ToString();
            return error;
        }
    }
}
