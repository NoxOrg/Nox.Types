namespace Nox.Types.Tests.Types;

public class YearTests
{
    [Fact]
    public void Year_Constructor_ReturnsSameValue()
    {
        var testYear = (ushort)1900;

        var number = Year.From(testYear);

        Assert.Equal(testYear, number.Value);
    }

    [Theory]
    [InlineData((ushort)0)]
    [InlineData((ushort)(100))]
    [InlineData((ushort)(1889))]
    [InlineData((ushort)(1880))]
    public void Year_Constructor_WithValueLess_ThanMinimiunSpecified_ThrowsValidationException(ushort value)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          Year.From(value)
        );

        // Assert
        Assert.Equal($"Could not create a Nox Year type as value {value} is less than the minimum specified value of 1900", exception.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData((ushort)3001)]
    [InlineData((ushort)(4001))]
    [InlineData((ushort)(5000))]
    [InlineData((ushort)(9999))]
    public void Year_Constructor_WithValueGreater_ThanMaximunSpecified_ThrowsValidationException(ushort value)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          Year.From(value)
        );

        // Assert
        Assert.Equal($"Could not create a Nox Year type a value {value} is greater than the maximum specified value of 3000", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Year_Equal_Tests()
    {
        // Arrange
        var year1 = Year.From(1900);

        var year2 = Year.From(1900);

        // Assert
        Assert.Equal(year1, year2);
    }

    [Fact]
    public void Year_NotEqual_Tests()
    {
        // Arrange
        var year1 = Year.From(2000);

        var year2 = Year.From(2002);

        // Assert
        Assert.NotEqual(year1, year2);
    }


    [Fact]
    public void Year_ToString_ReturnsString()
    {
        // Arrange
        var year = Year.From(1900);
        var year2 = Year.From(1990);

        // Assert
        Assert.Equal("1900", year.ToString());
        Assert.Equal("1990", year2.ToString());
    }

    [Fact]
    public void Year_Constructor_SpecifyingAllowFutureOnly_WithPassYearInput_ThrowsException()
    {
        var yearValue = (ushort)2020;

        Assert.Throws<TypeValidationException>(() => _ =
            Year.From(yearValue, new YearTypeOptions { AllowFutureOnly = true })
        );
    }

    [Fact]
    public void Year_Constructor_SpecifyingMaxValue_WithGreaterValueInput_ThrowsException()
    {
        var yearValue = (ushort)1900;

        Assert.Throws<TypeValidationException>(() => _ =
            Year.From(yearValue, new YearTypeOptions { MaxValue = 10 })
        );
    }

    [Fact]
    public void Year_Constructor_SpecifyingMinValue_WithLesserValueInput_ThrowsException()
    {
        var yearValue = (ushort)1;

        Assert.Throws<TypeValidationException>(() => _ =
            Year.From(yearValue, new YearTypeOptions { MinValue = 50 })
        );
    }
}