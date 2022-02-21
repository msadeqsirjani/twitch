using System;
using System.Linq;
using FluentAssertions;
using TwitchNightFall.Common.Common;
using Xunit;

namespace TwitchNightFall.Common.Test.Common
{
    public class ResultTest
    {
        [Fact]
        public void WithSuccess_ValidateResultMode()
        {
            var result = Result.WithSuccess();

            result.ResultMode.Should().Be(ResultMode.Success);
            result.Message.Should().BeNullOrEmpty();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void WithSuccessWithNotNullValue_ValidateResultMode()
        {
            var result = Result.WithSuccess(Enumerable.Empty<object>());

            result.ResultMode.Should().Be(ResultMode.Success);
            result.Message.Should().BeNullOrEmpty();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void WithSuccessWithNotNullValueAndNotNullMessage_ValidateResultMode()
        {
            const string message = "5B4B6D19-743F-4E57-AD89-71611D91DCB5";
            var result = Result.WithSuccess(new object(), message);

            result.ResultMode.Should().Be(ResultMode.Success);
            result.Message.Should().NotBeNullOrEmpty();
            result.Message.Should().BeEquivalentTo(message);
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void WithSuccessWithNotNullMessage_ValidateResultMode()
        {
            const string message = "5B4B6D19-743F-4E57-AD89-71611D91DCB5";
            var result = Result.WithSuccess(message);

            result.ResultMode.Should().Be(ResultMode.Success);
            result.Message.Should().NotBeNullOrEmpty();
            result.Message.Should().BeEquivalentTo(message);
            result.Value.Should().BeNull();
        }

        [Fact]
        public void WithMessage_ValidateResultMode()
        {
            const string message = "F5DC9AA8-6D67-4BEF-AF64-7AA024A61C6A";
            var result = Result.WithMessage(message);

            result.ResultMode.Should().Be(ResultMode.Message);
            result.Message.Should().NotBeNullOrEmpty();
            result.Message.Should().BeEquivalentTo(message);
            result.Value.Should().BeNull();
        }

        [Fact]
        public void WithException_ValidateResultMode()
        {
            var result = Result.WithException();

            result.ResultMode.Should().Be(ResultMode.Exception);
            result.Message.Should().BeNullOrEmpty();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void WithExceptionWithNotNullMessage_ValidateResultMode()
        {
            const string message = "795C53DD-EF56-4DBE-A82D-14CC634BBAFE";
            var result = Result.WithException(message);

            result.ResultMode.Should().Be(ResultMode.Exception);
            result.Message.Should().NotBeNullOrEmpty();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void WithExceptionWithNotNullExceptionNotNullMessage_ValidateResultMode()
        {
            const string message = "795C53DD-EF56-4DBE-A82D-14CC634BBAFE";
            var exception = new Exception(message);
            var result = Result.WithException(exception);

            result.ResultMode.Should().Be(ResultMode.Exception);
            result.Message.Should().NotBeNullOrEmpty();
            result.Message.Should().BeEquivalentTo(message);
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
