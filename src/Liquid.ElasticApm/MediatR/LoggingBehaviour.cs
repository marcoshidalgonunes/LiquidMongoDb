using System.Threading;
using System.Threading.Tasks;
using Elastic.Apm.Api;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Liquid.ElasticApm.MediatR
{
    /// <summary>
    /// Implements <see cref="IPipelineBehavior<TRequest, TResponse>"/> for Elastic APM.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">Type of response object obtained upon return of request.</typeparam>
    public sealed class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        private ITransaction _transaction;

        /// <summary>
        /// Initialize an instance of <see cref="LoggingBehaviour<TRequest, TResponse>"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger<LoggingBehaviour<TRequest, TResponse>>"/> implementation.</param>
        /// <param name="tracer">Elastic APM <see cref="ITracer"/> implementation.</param>
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger, ITracer tracer)
        {
            _logger = logger;
            _transaction = tracer?.CurrentTransaction;
        }

        /// <summary>
        /// Handles MediatR pipeline operation.
        /// </summary>
        /// <param name="request">The request command or query.</param>
        /// <param name="cancellationToken">Notification about operation to be cancelled.</param>
        /// <param name="next">Mext operation to be performed.</param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var span = _transaction?.StartSpan(typeof(TRequest).Name, typeof(TRequest).FullName, "MediatR");

            _logger?.LogInformation($"Handling {typeof(TRequest).Name}");           
            var response = await next();           
            _logger?.LogInformation($"Handled {typeof(TResponse).Name}"); 
            
            span?.End();

            return response;
        }
    }
}
