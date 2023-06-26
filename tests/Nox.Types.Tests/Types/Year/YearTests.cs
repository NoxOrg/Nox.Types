namespace Nox.Types.Tests.Types;

public class YearTests
{
    [Fact]
    public void Nox_Year_Constructor_ReturnsSameValue()
    {
        var testYear = (ushort)1;

        var number = Year.From(testYear);

        Assert.Equal(testYear, number.Value);
    }

    [Theory]
    [InlineData((ushort)0)]
    [InlineData((ushort)(19999))]
    public void Nox_Year_Constructor_WithOutOfRangeYear_ThrowsValidationException(ushort value)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          Year.From(value)
        );

        // Assert
        Assert.Equal($"Could not create a Nox Year type with unsupported value '{value}'. The value must be between 1 and 9999.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Year_Equality_Tests()
    {
        // Arrange
        var year1 = Year.From(1);

        var year2 = Year.From(1);

        // Assert
        Assert.Equal(year1, year2);
    }

    [Fact]
    public void Nox_Year_NotEqual_Tests()
    {
        // Arrange
        var year1 = Year.From(1);

        var year2 = Year.From(2);

        // Assert
        Assert.NotEqual(year1, year2);
    }


    [Fact]
    public void Nox_Year_ToString_ReturnsString()
    {
        // Arrange
        var year = Year.From(1);
        var year2 = Year.From(199);

        // Assert
        Assert.Equal("0001", year.ToString());
        Assert.Equal("0199", year2.ToString());
    }
}