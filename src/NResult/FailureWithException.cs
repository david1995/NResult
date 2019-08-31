using System;

namespace NResult
{
    public class FailureWithException : IFailureWithException
    {
        public FailureWithException(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }

    public class FailureWithException<T> : IFailureWithException<T>
    {
        public FailureWithException(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
