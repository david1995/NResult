using System;
using System.Collections.Generic;
using System.Linq;

namespace NResult
{
    /// <summary>
    /// A static factory class for the included Result values.
    /// </summary>
    public static class Result
    {
        public static ISuccess Success()
        {
            return new Success();
        }

        public static IFailure Failure()
        {
            return new Failure();
        }

        public static IFailureWithMessage Failure(string message)
        {
            return new FailureWithMessage(message);
        }

        public static IFailureWithException Failure(Exception exception)
        {
            return new FailureWithException(exception);
        }

        public static IAggregateFailure Failure(IEnumerable<IFailure> failuresToAggregate)
        {
            return new AggregateFailure(failuresToAggregate.ToArray());
        }

        public static IAggregateFailure Failure(params IFailure[] failuresToAggregate)
        {
            return new AggregateFailure(failuresToAggregate.AsEnumerable().ToArray());
        }

        public static ISuccess<T> Success<T>(T value)
        {
            return new Success<T>(value);
        }

        public static IFailure<T> Failure<T>()
        {
            return new Failure<T>();
        }

        public static IFailureWithMessage<T> Failure<T>(string message)
        {
            return new FailureWithMessage<T>(message);
        }

        public static IFailureWithException<T> Failure<T>(Exception exception)
        {
            return new FailureWithException<T>(exception);
        }

        public static IAggregateFailure<T> Failure<T>(IEnumerable<IFailure> failuresToAggregate)
        {
            return new AggregateFailure<T>(failuresToAggregate.ToArray());
        }

        public static IAggregateFailure<T> Failure<T>(params IFailure[] failuresToAggregate)
        {
            return new AggregateFailure<T>(failuresToAggregate.AsEnumerable().ToArray());
        }

        public static bool IsFailure(IResult result)
        {
            return result is IFailure _;
        }

        public static bool IsSuccess(IResult result)
        {
            return result is ISuccess _;
        }
    }
}
