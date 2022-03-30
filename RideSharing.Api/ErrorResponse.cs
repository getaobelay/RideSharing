namespace RideSharing.Api
{
    public class ErrorResponse
    {
        public bool IsError { get; set; } = true;
        public int StatusCode { get; set; }
        public string ErrorPharse { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public DateTime TimeStamp { get; set; }
    }
}
