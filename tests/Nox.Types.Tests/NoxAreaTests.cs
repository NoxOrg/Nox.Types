using FluentValidation;

namespace Nox.Types.Tests;

public class NoxAreaTests
{
    [Fact]
    public void Nox_Area_Constructor_ReturnsSameValueAndUnit()
    {
        var area = Area.From(12.5, AreaTypeUnit.SquareMeter);

        Assert.Equal(12.5, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(-12.5, AreaTypeUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type as value -12.5 is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithZeroValueInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(0, AreaTypeUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type as value 0 is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNaNValueInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(double.NaN, AreaTypeUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type as value NaN is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(double.PositiveInfinity, AreaTypeUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type as value PositiveInfinity or NegativeInfinity are not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(double.NegativeInfinity, AreaTypeUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type as value PositiveInfinity or NegativeInfinity are not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithUnsupportedAreaUnitInput_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
            Area.From(12.5)
        );

        Assert.Equal("Could not create a Nox Area type as area unit Unknown is not supported.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Equality_WithSameAreaUnit_Tests()
    {
        var squareMetersValue = 12.5;

        var area1 = Area.From(squareMetersValue, AreaTypeUnit.SquareMeter);

        var area2 = Area.From(squareMetersValue, AreaTypeUnit.SquareMeter);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_Equality_WithDifferentAreaUnit_Tests()
    {
        var squareMetersValue = 12.5;
        var area1 = Area.From(squareMetersValue, AreaTypeUnit.SquareMeter);

        var squareFeetValue = 134.54888; // 12.5 m²
        var area2 = Area.From(squareFeetValue, AreaTypeUnit.SquareFoot);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_NonEquality_SpecifyingAreaUnit_WithSameUnit_Tests()
    {
        var squareMetersValue1 = 12.5;
        var area1 = Area.From(squareMetersValue1, AreaTypeUnit.SquareMeter);

        var squareMetersValue2 = 13.0;
        var area2 = Area.From(squareMetersValue2, AreaTypeUnit.SquareMeter);

        AssertAreNotEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_NonEquality_SpecifyingAreaUnit_WithDifferentUnit_Tests()
    {
        var squareMetersValue = 12.5;
        var area1 = Area.From(squareMetersValue, AreaTypeUnit.SquareMeter);

        var squareFeetValue = 139.930835; // 13 m²
        var area2 = Area.From(squareFeetValue, AreaTypeUnit.SquareFoot);

        AssertAreNotEquivalent(area1, area2);
    }

    private static void AssertAreEquivalent(Area expected, Area actual)
    {
        Assert.Equal(expected, actual);

        Assert.True(expected.Equals(actual));

        Assert.True(actual.Equals(expected));

        Assert.True(expected == actual);

        Assert.False(expected != actual);
    }

    private static void AssertAreNotEquivalent(Area expected, Area actual)
    {
        Assert.NotEqual(expected, actual);

        Assert.False(expected.Equals(actual));

        Assert.False(actual.Equals(expected));

        Assert.False(expected == actual);

        Assert.True(expected != actual);
    }
}