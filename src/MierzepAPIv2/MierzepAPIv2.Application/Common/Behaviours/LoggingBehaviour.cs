using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Common.Behaviours
{
    /// <summary>
    /// Logowanie danych - IRequestPreProcessor jest częścią Mediator. Oznacza behavior który wykoan się przed wejściem
    /// do tego pipline
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;
        
        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Text Menagment : {Name} {@Request}", requestName, request);
        }
    }
}
