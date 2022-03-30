namespace RideSharing.Shared
{
    public enum ErrorCode
    {
        NotFound = 404,
        ServerError = 500,
        BadRequest = 400,
        OrderItemPicked = 501,
        OrderItemShipped = 502,
        NotValid = 503,
        AlreadyExists = 504,
        OrderInProcces = 505,
        OrderNotPicked = 506,
        OrderShipped = 507
    }

    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}