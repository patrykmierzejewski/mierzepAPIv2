
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Common.Behaviours
{
    /// <summary>
    /// Klasa która sprawdza performance :
    /// Zachowanie które pokazuje cały pipline,
    /// Od requestu do responsa.
    /// </summary>
    /// <typeparam name="TRequest">TRequest</typeparam>
    /// <typeparam name="TResponse">TResponse</typeparam>
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsed = _timer.ElapsedMilliseconds;

            if (elapsed > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogInformation("Text Menagment Long Running request : {Name} ({elapsed} Milliseconds) {@Request}", requestName, elapsed, request);
            }

            return response;
        }
    }
}
