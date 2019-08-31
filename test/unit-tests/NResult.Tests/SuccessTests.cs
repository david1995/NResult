using FluentAssertions;
using Xunit;

namespace NResult.Tests
{
    public class SuccessTests
    {
        [Fact]
        public void Constructor_Value_ShouldReturnSuccessWithValue()
        {
            // ARRANGE
            const string value = "this is the success value";

            // ACT
            var success = new Success<string>(value);

            // ASSERT
            success.Value.Should().Be(value);
        }
    }
}
