using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ShoppingWebservice.DTO;

namespace ShoppingWebservice.ErrorHandling {
    public class SqlExceptionFilterAttribute : ExceptionFilterAttribute {

        public override void OnException(HttpActionExecutedContext context) {
            if (context.Exception is SqlException) {
                context.Exception.HelpLink 
                    = "https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlexception(v=vs.110).aspx";

                ResponseDTO responseDto = new ResponseDTO {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "SQL Exception",
                    MessageDetail 
                    = context.Exception.Message + ". Please visit " + context.Exception.HelpLink + " for help."
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, responseDto);
            }
        }
    }
}