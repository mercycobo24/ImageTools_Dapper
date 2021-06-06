using FluentValidation;
using ImageTool.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageTool.Filters
{
    public class ValidationFilter1<TRequest,Tresponse> : IPipelineBehavior<TRequest,Tresponse> where TRequest : IRequest<Tresponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationFilter1(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<Tresponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                            .Select(x => x.Validate(context))
                            .SelectMany(x => x.Errors)
                            .Where(x => x != null)
                            .ToList();
            var errorResponse = new List<ErrorModel>();
            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    var errorModel = new ErrorModel
                    {
                        FieldName = "",
                        Message = failure.ErrorMessage
                    };
                }

             }
            
            //return errorResponse;
            return await  next();
        }
    }
}
