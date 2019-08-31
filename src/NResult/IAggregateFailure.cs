using System.Collections.Generic;

namespace NResult
{
    public interface IAggregateFailure : IFailure
    {
        IReadOnlyList<IFailure> Failures { get; }
    }

    public interface IAggregateFailure<T> : IAggregateFailure, IFailure<T>
    {
    }
}
