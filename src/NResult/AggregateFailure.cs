using System.Collections.Generic;

namespace NResult
{
    public class AggregateFailure : IAggregateFailure
    {
        public AggregateFailure(IReadOnlyList<IFailure> failures)
        {
            Failures = failures;
        }

        public AggregateFailure(params IFailure[] failures)
            : this((IReadOnlyList<IFailure>)failures)
        {
        }

        public IReadOnlyList<IFailure> Failures { get; }
    }

    public class AggregateFailure<T> : IAggregateFailure<T>
    {
        public AggregateFailure(IReadOnlyList<IFailure> failures)
        {
            Failures = failures;
        }

        public AggregateFailure(params IFailure[] failures)
            : this((IReadOnlyList<IFailure>)failures)
        {
        }

        public IReadOnlyList<IFailure> Failures { get; }
    }
}
