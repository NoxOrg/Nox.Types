﻿namespace Nox.Types.Tests;

public class NoxAreaTests
{
    [Fact]
    public void Nox_Area_Constructor_ReturnsDefaultValueAndUnit()
    {
        var area = new Area();

        Assert.Equal(0, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var area = Area.From(12.5);

        Assert.Equal(12.5, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_ReturnsRoundedValueAndDefaultUnit()
    {
        var area = Area.From(12.54888020887151);

        Assert.Equal(12.548880, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var area = Area.From(12.5, AreaTypeUnit.SquareMeter);

        Assert.Equal(12.5, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_WithUnitInSquareMeters_ReturnsSameValueAndUnit()
    {
        var area = Area.FromSquareMeters(12.5);

        Assert.Equal(12.5, area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_WithUnitInSquareFeet_ReturnsSameValueAndUnit()
    {
        var area = Area.FromSquareFeet(134.548880);

        Assert.Equal(134.548880, area.Value);
        Assert.Equal(AreaTypeUnit.SquareFoot, area.Unit);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Area.From(-12.5)
        );

        Assert.Equal("Could not create a Nox Area type as negative area value -12.5 is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNaNValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Area.From(double.NaN)
        );

        Assert.Equal("Could not create a Nox type as value NaN is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Area.From(double.PositiveInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Area.From(double.NegativeInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_Constructor_WithWithUnsupportedUnitInput_ThrowsException()
    {
        var exception = Assert.Throws<NotImplementedException>(() => _ =
            Area.From(12.5, (AreaTypeUnit)1001)
        );

        Assert.Equal("No conversion defined from 1001 to SquareMeter.", exception.Message);
    }

    [Fact]
    public void Nox_Area_Constructor_WithNotAllowedValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Area.From(510_072_000_000_001)
        );

        Assert.Equal($"Could not create a Nox Area type as value 510072000000001 is greater than the surface area of the Earth.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_Area_ToSquareMeters_ReturnsValue()
    {
        var squareMeters = 12.5;
        
        var area = Area.From(squareMeters);

        Assert.Equal(12.5, area.ToSquareMeters());
    }

    [Fact]
    public void Nox_Area_ToSquareFeet_ReturnsValue()
    {
        var squareMeters = 12.5;

        var area = Area.From(squareMeters);

        Assert.Equal(134.54888, area.ToSquareFeet());
    }

    [Fact]
    public void Nox_Area_ValueInSquareMeters_ToString_ReturnsString()
    {
        var area = Area.FromSquareMeters(12.5);

        Assert.Equal("12.5 m²", area.ToString());
    }

    [Fact]
    public void Nox_Area_ValueInSquareFeet_ToString_ReturnsString()
    {
        var area = Area.FromSquareFeet(134.548880);

        Assert.Equal("134.54888 ft²", area.ToString());
    }

    [Fact]
    public void Nox_Area_Equality_WithSameAreaUnit_Tests()
    {
        var squareMeters = 12.5;

        var area1 = Area.From(squareMeters, AreaTypeUnit.SquareMeter);

        var area2 = Area.From(squareMeters, AreaTypeUnit.SquareMeter);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_Equality_WithDifferentAreaUnit_Tests()
    {
        var squareMeters = 12.5;
        var area1 = Area.From(squareMeters, AreaTypeUnit.SquareMeter);

        var squareFeetValue = 134.54888; // 12.5 m²
        var area2 = Area.From(squareFeetValue, AreaTypeUnit.SquareFoot);

        AssertAreEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_NonEquality_SpecifyingAreaUnit_WithSameUnit_Tests()
    {
        var squareMeters1 = 12.5;
        var area1 = Area.From(squareMeters1, AreaTypeUnit.SquareMeter);

        var squareMeters2 = 13.0;
        var area2 = Area.From(squareMeters2, AreaTypeUnit.SquareMeter);

        AssertAreNotEquivalent(area1, area2);
    }

    [Fact]
    public void Nox_Area_NonEquality_SpecifyingAreaUnit_WithDifferentUnit_Tests()
    {
        var squareMeters = 12.5;
        var area1 = Area.From(squareMeters, AreaTypeUnit.SquareMeter);

        var squareFeet = 139.930835; // 13 m²
        var area2 = Area.From(squareFeet, AreaTypeUnit.SquareFoot);

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