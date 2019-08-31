using System.Collections.Generic;

namespace NResult.Extensions
{
    public static class ResultExtensions
    {
        public static IResult Box(IResult result)
        {
            return result;
        }

        public static IResult<T> Box<T>(IResult<T> result)
        {
            return result;
        }

        public static bool IsFailure(this IResult result)
        {
            return Result.IsFailure(result);
        }

        public static bool IsSuccess(this IResult result)
        {
            return Result.IsSuccess(result);
        }

        public static IAggregateFailure Aggregate(this IFailure failure1, IFailure failure2)
        {
            return Result.Failure(failure1, failure2);
        }

        public static IAggregateFailure<T> Aggregate<T>(this IFailure failure1, IFailure failure2)
        {
            return Result.Failure<T>(failure1, failure2);
        }

        public static IAggregateFailure Aggregate(this IAggregateFailure aggregateFailure, IFailure failure)
        {
            return Result.Failure(aggregateFailure.Failures.Append(failure));
        }

        public static IAggregateFailure<T> Aggregate<T>(this IAggregateFailure aggregateFailure, IFailure failure)
        {
            return Result.Failure<T>(aggregateFailure.Failures.Append(failure));
        }

        internal static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T valueToAppend)
        {
            foreach (var value in enumerable)
            {
                yield return value;
            }

            yield return valueToAppend;
        }
    }
}
