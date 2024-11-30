using EmploymentSystem.Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validators.Select(t => t.ValidateAsync(validationContext, cancellationToken)));
                var errors = result.SelectMany(t => t.Errors).Where(t => t != null).ToList();
                if (errors.Any())
                {
                    throw new CustomValidationException(errors);
                }
            }
            return await next();
        }
    }
}
