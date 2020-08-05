using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Serilog;

namespace OfficeAuthomation.Servicess.PipelineBehaviors
{
    public class ErrorHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {



            try
            {
                var response = await next();

                return response;
            }
            catch (Exception e)
            {
                throw new ValidationException(e.Message);
            }
        }
    }
}
