using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using NLog;
using ShoppingWebservice.Shared.DTOs;
using ShoppingWebservice.Shared.ErrorHandling;

namespace ShoppingWebservice.Shared.Config {

    public static class ResponseHandler {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static NegotiatedContentResult<ResponseDto> SuccessResponse(ResponseDto dto, ApiController ctrl) {
            Logger.Trace("Success: ");

            return new NegotiatedContentResult<ResponseDto>(HttpStatusCode.OK, dto, ctrl);
        }

        public static NegotiatedContentResult<ResponseDto> ErrorResponse(ErrorDto error, ApiController ctrl) {
            Logger.Error("Error : " + error.ErrorMsg + " in " + error.ClassType + " " + error.ErrorWhen);

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string msg = error.ErrorMsg;

            if (error.ErrorType == ErrorType.EmptyTableError) {
                statusCode = HttpStatusCode.BadRequest;
            }

            return new NegotiatedContentResult<ResponseDto>(statusCode, new ResponseDto {Message = msg}, ctrl);
        }
    }
}