using System.Linq;
using FluentAssertions;
using NResult.Extensions;
using Xunit;

namespace NResult.Tests
{
    public class FailureTests
    {
        [Fact]
        public void AggregateFailureConstructor_FailuresToAggregate_ShouldReturnAggregateFailureWithAggregatedFailure()
        {
            // ARRANGE
            var baseFailure = new FailureWithMessage("Base failure");
            var failureToAggregate = new FailureWithMessage("Failure to aggregate");
            var expectedFailures = new IFailure[] { baseFailure, failureToAggregate };

            // ACT
            var aggregatedFailure = new AggregateFailure(new[] { baseFailure, failureToAggregate });

            // ASSERT
            aggregatedFailure.Failures.Should().BeEquivalentTo(expectedFailures.AsEnumerable());
        }

        [Fact]
        public void Aggregate_AggregateFailureAndFailuretoAggregate_ShouldReturnAggregateFailure()
        {
            // ARRANGE
            var aggregateFailure = new AggregateFailure(new []{ new FailureWithMessage("Base failure") });
            var failureToAggregate = new FailureWithMessage("Failure to aggregate");

            // ACT
            var aggregatedFailure = aggregateFailure.Aggregate(failureToAggregate);

            // ASSERT
            aggregatedFailure.Should().BeAssignableTo<IAggregateFailure>();
        }

        [Fact]
        public void Aggregate_AggregateFailureAndFailuretoAggregate_ShouldReturnAggregateFailureWithAggregatedFailures()
        {
            // ARRANGE
            var baseFailure = new FailureWithMessage("Base failure");
            var baseAggregateFailure = new AggregateFailure(new []{ baseFailure });
            var failureToAggregate = new FailureWithMessage("Failure to aggregate");
            var expectedFailures = new IFailure[] { baseFailure, failureToAggregate };

            // ACT
            var aggregatedFailure = baseAggregateFailure.Aggregate(failureToAggregate);

            // ASSERT
            aggregatedFailure.Should().BeAssignableTo<IAggregateFailure>()
                             .Which.Failures.Should().BeEquivalentTo(expectedFailures.AsEnumerable());
        }
    }
}
