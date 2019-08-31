using System;

namespace NResult
{
    public interface IFailureWithException : IFailure
    {
        Exception Exception { get; }
    }

    public interface IFailureWithException<T> : IFailureWithException, IFailure<T>
    {
    }
}
