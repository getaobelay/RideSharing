using Microsoft.AspNetCore.Mvc;
using RideSharing.Shared;

namespace RideSharing.Api
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code.Equals(ErrorCode.NotFound)))
            {
                var error = errors.SingleOrDefault(e => e.Code == ErrorCode.NotFound);

                apiError.StatusCode = (int)ErrorCode.NotFound;
                apiError.ErrorPharse = "Not Found";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            if (errors.Any(e => e.Code.Equals(ErrorCode.AlreadyExists)))
            {
                var error = errors.SingleOrDefault(e => e.Code == ErrorCode.AlreadyExists);

                apiError.StatusCode = (int)ErrorCode.AlreadyExists;
                apiError.ErrorPharse = "Already exists";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return BadRequest(apiError);
            }

            if (errors.Any(e => e.Code.Equals(ErrorCode.NotValid)))
            {
                var error = errors.SingleOrDefault(e => e.Code == ErrorCode.NotValid);

                apiError.StatusCode = (int)ErrorCode.NotValid;
                apiError.ErrorPharse = "Not Valid";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return BadRequest(apiError);
            }

            if (errors.Any(e => e.Code.Equals(ErrorCode.BadRequest)))
            {
                var error = errors.SingleOrDefault(e => e.Code == ErrorCode.BadRequest);

                apiError.StatusCode = (int)ErrorCode.BadRequest;
                apiError.ErrorPharse = "Bad Request";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return BadRequest(apiError);
            }

            apiError.StatusCode = (int)ErrorCode.ServerError;
            apiError.ErrorPharse = "Internal server error";
            apiError.TimeStamp = DateTime.Now;
            apiError.Errors.Add("Unknown error");

            return StatusCode(500, apiError);
        }
    }
}
