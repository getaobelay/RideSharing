using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RideSharing.Shared;

namespace RideSharing.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();
                apiError.StatusCode = (int)ErrorCode.BadRequest;
                apiError.ErrorPharse = "Bad request";
                apiError.TimeStamp = DateTime.Now;

                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    apiError.Errors.Add(error.Value.ToString());
                }

                context.Result = new BadRequestObjectResult(apiError);
            }
        }
    }
}
