using System.Threading;
using System.Threading.Tasks;
using Elastic.Apm.Api;
using MediatR;

namespace Liquid.ElasticApm.MediatR
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ITracer _tracer;

        protected BaseRequestHandler(ITracer tracer) => _tracer = tracer;

        protected abstract Task<TResponse> DoHandle(TRequest request, CancellationToken cancellationToken);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            //var span = _tracer?.CurrentTransaction?.StartSpan($"IRequestHandler<{typeof(TRequest).Name}, {typeof(TResponse).Name}>", "Handle");
            try
            {
                return await DoHandle(request, cancellationToken);
            }
            finally
            {
                //span?.End();
            }
        }
    }
}
