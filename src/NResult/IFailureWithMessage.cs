namespace NResult
{
    public interface IFailureWithMessage : IFailure
    {
        string Message { get; }
    }

    public interface IFailureWithMessage<T> : IFailureWithMessage, IFailure<T>
    {
    }
}
