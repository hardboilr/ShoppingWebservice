using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using ShoppingWebservice.Shared.DTOs;

namespace ShoppingWebservice.ErrorHandling {
    // http://stackoverflow.com/questions/25395407/how-to-catch-all-exceptions-in-web-api-2

    public class ServerExceptionHandler : IExceptionHandler {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken) {
            ResponseDto responseDto = new ResponseDto {
                Message = "Ups... Something went wrong...",
            };
            HttpResponseMessage response = 
                context.Request.CreateResponse(HttpStatusCode.InternalServerError, responseDto);
            context.Result = new ResponseMessageResult(response);

            return Task.FromResult(0);
        }
    }
}