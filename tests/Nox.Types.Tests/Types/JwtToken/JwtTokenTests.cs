using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class JwtTokenTests
{
    [Fact]
    public void JwtToken_Constructor_ReturnsSameValue()
    {
        var value = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var jwtToken = JwtToken.From(value);

        Assert.Equal(value, jwtToken.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void JwtToken_Constructor_WithNullOrEmptyStringValue_ThrowsException(string value)
    {
        var action = () => JwtToken.From(value);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox JWT Token type as the value cannot be null or empty string.") });
    }

    [Theory]
    [InlineData("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ")] // missing last segment
    public void JwtToken_Constructor_WithInvalidJWTFormatValue_ThrowsException(string value)
    {
        var action = () => JwtToken.From(value);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox JWT Token type as value {value} does not have a valid JWT format.") });
    }
}
