namespace NResult
{
    public class FailureWithMessage : IFailureWithMessage
    {
        public FailureWithMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class FailureWithMessage<T> : IFailureWithMessage<T>
    {
        public FailureWithMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
