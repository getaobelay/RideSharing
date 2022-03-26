using System.Runtime.Serialization;

namespace RideSharing.Abstractions.Exceptions
{
    [Serializable]
    public class NotValidException : Exception
    {
        public NotValidException()
        {
        }

        public NotValidException(string? message) : base(message)
        {
        }

        public NotValidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public NotValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public List<string> Errors { get; set; } = new List<string>();
    }
}