using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Common.Behaviours
{
    /// <summary>
    /// Validator for custom Fluent Validation for object Vm.
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResposne">Resposne</typeparam>
    public class ValidationBehaviour<TRequest, TResposne> : IPipelineBehavior<TRequest, TResposne>
        where TRequest : IRequest<TResposne>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResposne> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResposne> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(x => x.Validate(context)).SelectMany(x => x.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count > 0)
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
