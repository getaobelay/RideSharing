using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RideSharing.Shared;

namespace RideSharing.Api.Filters
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var apiError = new ErrorResponse();
            apiError.StatusCode = (int)ErrorCode.ServerError;
            apiError.ErrorPharse = "Internal server error";
            apiError.TimeStamp = DateTime.Now;
            apiError.Errors.Add(context.Exception.Message);

            context.Result = new JsonResult(apiError) { StatusCode = apiError.StatusCode };
        }
    }
}
