// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class LengthTests
{
    [Fact]
    public void Length_Constructor_ReturnsSameValueAndDefaultUnit()
    {
        var length = Length.From(95.755663);

        Assert.Equal(95.755663, length.Value);
        Assert.Equal(LengthTypeUnit.Meter, length.Unit);
    }

    [Fact]
    public void Length_Constructor_WithUnit_ReturnsSameValueAndUnit()
    {
        var length = Length.From(314.158999, LengthTypeUnit.Foot);

        Assert.Equal(314.158999, length.Value);
        Assert.Equal(LengthTypeUnit.Foot, length.Unit);
    }

    [Fact]
    public void Length_Constructor_WithUnitInFeet_ReturnsSameValueAndUnit()
    {
        var length = Length.FromFeet(314.158999);

        Assert.Equal(314.158999, length.Value);
        Assert.Equal(LengthTypeUnit.Foot, length.Unit);
    }

    [Fact]
    public void Length_Constructor_WithUnitInMeters_ReturnsSameValueAndUnit()
    {
        var length = Length.FromMeters(95.755663);

        Assert.Equal(95.755663, length.Value);
        Assert.Equal(LengthTypeUnit.Meter, length.Unit);
    }

    [Fact]
    public void Length_Constructor_WithNegativeValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Length.From(-100)
        );

        Assert.Equal("Could not create a Nox Length type as negative length value -100 is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Length_Constructor_WithNaNValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Length.From(double.NaN)
        );

        Assert.Equal("Could not create a Nox type as value NaN is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Length_Constructor_WithPositiveInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Length.From(double.PositiveInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Length_Constructor_WithNegativeInfinityValueInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Length.From(double.NegativeInfinity)
        );

        Assert.Equal("Could not create a Nox type as value Infinity is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Length_Constructor_WithWithUnsupportedUnitInput_ThrowsException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            Length.From(95.755663, (LengthTypeUnit)1001)
        );

        Assert.Equal("Could not create a Nox Length type as unit 1001 is not supported.", exception.Errors.First().ErrorMessage);
    }


    [Fact]
    public void Length_ToMeters_ReturnsValueInMeters()
    {
        var length = Length.FromMeters(95.755663);

        Assert.Equal(95.755663, length.ToMeters());
    }

    [Fact]
    public void Length_ToFeet_ReturnsValueInFeet()
    {
        var length = Length.FromMeters(95.755663);

        Assert.Equal(314.158999, length.ToFeet());
    }

    [Fact]
    public void Length_ValueInMeters_ToString_ReturnsValueAndUnit()
    {
        void Test()
        {
            var length = Length.FromMeters(95.755663);
            Assert.Equal("95.755663 m", length.ToString());
        }
        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Length_ValueInFeet_ToString_ReturnsValueAndUnit()
    {
        void Test()
        {
            var length = Length.FromFeet(314.158999);
            Assert.Equal("314.158999 ft", length.ToString());
        }
        TestUtility.RunInInvariantCulture(Test);
    }

    [Fact]
    public void Length_Equality_SpecifyingLengthUnit_WithSameUnit_Tests()
    {
        var length1 = Length.FromMeters(95.755663);

        var length2 = Length.FromMeters(95.755663);

        AssertAreEquivalent(length1, length2);
    }

    [Fact]
    public void Length_Equality_SpecifyingLengthUnit_WithDifferentUnit_Tests()
    {
        var length1 = Length.FromMeters(95.755663);

        var length2 = Length.FromFeet(314.158999);

        AssertAreEquivalent(length1, length2);
    }

    [Fact]
    public void Length_NonEquality_SpecifyingLengthUnit_WithSameUnit_Tests()
    {
        var length1 = Length.FromMeters(95.755663);

        var length2 = Length.FromMeters(314.158999);

        AssertAreNotEquivalent(length1, length2);
    }

    [Fact]
    public void Length_NonEquality_SpecifyingLengthUnit_WithDifferentUnit_Tests()
    {
        var length1 = Length.FromMeters(95.755663);

        var length2 = Length.FromFeet(95.755663);

        AssertAreNotEquivalent(length1, length2);
    }

    private static void AssertAreEquivalent(Length expected, Length actual)
    {
        Assert.Equal(expected, actual);

        Assert.True(expected.Equals(actual));

        Assert.True(actual.Equals(expected));

        Assert.True(expected == actual);

        Assert.False(expected != actual);
    }

    private static void AssertAreNotEquivalent(Length expected, Length actual)
    {
        Assert.NotEqual(expected, actual);

        Assert.False(expected.Equals(actual));

        Assert.False(actual.Equals(expected));

        Assert.False(expected == actual);

        Assert.True(expected != actual);
    }
}