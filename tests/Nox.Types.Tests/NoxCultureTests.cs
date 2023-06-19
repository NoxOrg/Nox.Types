namespace Nox.Types.Tests;

public class NoxCultureTests
{
    [Fact]
    public void Culture_WithValidValues_ShouldBeValid()
    {
        // Arrange
        string code = "en-US";
        string displayName = "English (United States)";

        // Act
        var culture = Culture.From(code, displayName);

        // Assert
        Assert.Equal(code, culture.Code);
        Assert.Equal(displayName, culture.DisplayName);
    }

    [Theory]
    [InlineData(null, "English (United States)")]
    [InlineData("", "English (United States)")]
    [InlineData("en-US", null)]
    [InlineData("en-US", "")]
    public void Culture_WithInvalidValues_ShouldBeInvalid(string code, string displayName)
    {
        // Arrange & Act & Assert
        Assert.Throws<TypeValidationException>(() => Culture.From(code, displayName));
    }

    [Fact]
    public void Culture_ToString_ReturnsCode()
    {
        // Arrange
        string code = "en-US";
        string displayName = "English (United States)";
        var culture = Culture.From(code, displayName);

        // Act
        string result = culture.ToString();

        // Assert
        Assert.Equal(code, result);
    }
}