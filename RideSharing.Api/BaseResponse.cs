namespace RideSharing.Api
{
    public record BaseResponse
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
