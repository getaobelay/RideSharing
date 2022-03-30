namespace RideSharing.Shared
{
    public class Result<T>
    {
        public Result()
        { }

        public Result(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public List<Error> Errors { get; internal set; } = new();
        public bool IsError { get; private set; } = false;

        public void AddError(ErrorCode code, string Message)
        {
            IsError = true;
            Errors.Add(new Error { Code = code, Message = Message });
        }

        public void AddServerError(string Message)
        {
            IsError = true;
            Errors.Add(new Error { Code = ErrorCode.ServerError, Message = Message });
        }

        public void ResetErrorState()
        {
            IsError = false;
        }
    }
}