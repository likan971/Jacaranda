using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using Jacaranda.Data;
using Jacaranda.Utilities;

namespace Jacaranda.Api.Infrastructure.Filters
{
    public class ExceptionLogger : IAutofacExceptionFilter
    {
        private IErrorLoggerService _loggerService;

        public ExceptionLogger(IErrorLoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var requestUrl = actionExecutedContext.Request.RequestUri.AbsolutePath;
            var requestBody = actionExecutedContext.Request.GetBodyString();
            var exMessage = actionExecutedContext.Exception.GetFullMessages();
            var exStackTrace = actionExecutedContext.Exception.StackTrace;

            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Server Error!");

            await _loggerService.LogErrorToDbAsync(requestUrl, requestBody, exMessage, exStackTrace);
        }
    }
}