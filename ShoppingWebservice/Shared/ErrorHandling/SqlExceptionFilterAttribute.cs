using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ShoppingWebservice.Shared.DTOs;

namespace ShoppingWebservice.Shared.ErrorHandling {

    public class SqlExceptionFilterAttribute : ExceptionFilterAttribute {

        public override void OnException(HttpActionExecutedContext context) {
            if (context.Exception is SqlException) {
                context.Exception.HelpLink 
                    = "https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlexception(v=vs.110).aspx";

                ResponseDto responseDto = new ResponseDto {
                    Message = "SQL Exception",
                };

                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, responseDto);
            }
        }
    }
}