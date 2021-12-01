using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Elastic.Apm;
using Elastic.Apm.Api;
using Liquid.Core.Base;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Core
{
    public class LiquidElasticApmInterceptor : LiquidInterceptorBase
    {
        private readonly ILogger<LiquidElasticApmInterceptor> _logger;

        private readonly ITracer _tracer;

        private ISpan span;

        public LiquidElasticApmInterceptor(ILogger<LiquidElasticApmInterceptor> logger, ITracer tracer)
        {
            _logger = logger;
            _tracer = tracer;
        }

        protected override Task AfterInvocation<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, TResult result)
        {
            span?.End();
            return Task.CompletedTask;
        }

        protected override Task BeforeInvocation(IInvocation invocation, IInvocationProceedInfo proceedInfo)
        {
            span = _tracer?.CurrentTransaction?.StartSpan(invocation.TargetType.Name, invocation.Method.Name);
            return Task.CompletedTask;
        }

        protected override Task OnExceptionInvocation(IInvocation invocation, IInvocationProceedInfo proceedInfo, Exception exception)
        {
            span?.End();

            _logger.LogError(exception, "Execution of {methodName} from {typeFullName} has thrown an exception.", invocation.Method.Name, invocation.TargetType.FullName);
            return Task.CompletedTask;
        }
    }
}
