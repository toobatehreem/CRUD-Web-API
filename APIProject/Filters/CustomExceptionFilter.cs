using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace APIProject.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errMsg = string.Empty;
            var exception = actionExecutedContext.Exception.GetType();
            if (exception == typeof(UnauthorizedAccessException))
            {
                errMsg = "Unauthorized Access!";
                statusCode = HttpStatusCode.Unauthorized;

            }
            else if (exception == typeof(NullReferenceException))
            {
                errMsg = "Data is not found!";
                statusCode = HttpStatusCode.NotFound;

            }
            
            else
            {
                errMsg = "Contact to Admin!";
                statusCode = HttpStatusCode.InternalServerError;
            }

            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errMsg),
                ReasonPhrase = "From Exception Filter"
            };

            actionExecutedContext.Response = response;

            base.OnException(actionExecutedContext);
        }
    }
}
