using System;
using System.IO;
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
            var aggregatedFailure = new AggregateFailure(baseFailure, failureToAggregate);

            // ASSERT
            aggregatedFailure.Failures.Should().BeEquivalentTo(expectedFailures.AsEnumerable());
        }

        [Fact]
        public void Aggregate_AggregateFailureAndFailureToAggregate_ShouldReturnAggregateFailure()
        {
            // ARRANGE
            var aggregateFailure = new AggregateFailure(new FailureWithMessage("Base failure"));
            var failureToAggregate = new FailureWithMessage("Failure to aggregate");

            // ACT
            var aggregatedFailure = aggregateFailure.Aggregate(failureToAggregate);

            // ASSERT
            aggregatedFailure.Should().BeAssignableTo<IAggregateFailure>();
        }

        [Fact]
        public void Aggregate_AggregateFailureAndFailureToAggregate_ShouldReturnAggregateFailureWithAggregatedFailures()
        {
            // ARRANGE
            var baseFailure = new FailureWithMessage("Base failure");
            var baseAggregateFailure = new AggregateFailure(baseFailure);
            var failureToAggregate = new FailureWithMessage("Failure to aggregate");
            var expectedFailures = new IFailure[] { baseFailure, failureToAggregate };

            // ACT
            var aggregatedFailure = baseAggregateFailure.Aggregate(failureToAggregate);

            // ASSERT
            aggregatedFailure.Should()
               .BeAssignableTo<IAggregateFailure>()
               .Which.Failures.Should()
               .BeEquivalentTo(expectedFailures.AsEnumerable());
        }

        [Fact]
        public void FlattenFailure_FailureStructure_ShouldReturnAllLeafFailures()
        {
            // ARRANGE
            var failure = new AggregateFailure(
                new AggregateFailure(
                    new FailureWithMessage("test"),
                    new FailureWithException(new InvalidOperationException()),
                    new AggregateFailure(new FailureWithException(new ArgumentOutOfRangeException()))
                ),
                new FailureWithMessage("rootLevel"),
                new FailureWithException(new NotSupportedException()),
                new AggregateFailure(
                    new Failure(),
                    new FailureWithException(new IOException())
                )
            );

            var expectedCount = 7;

            // ACT
            var actualFlattenedFailures = failure.FlattenFailure();

            // ASSERT
            actualFlattenedFailures.Should().HaveCount(expectedCount);
        }
    }
}
