using System.Globalization;
using FluentValidation;

namespace Nox.Types.Tests;

public class NoxLatLongTests
{
    [Fact]
    public void Nox_LatLong_Constructor_ReturnsSameValue()
    {
        var coords = LatLong.From(46.94809, 7.44744);

        Assert.Equal((46.94809, 7.44744), coords.Value);
    }

    [Fact]
    public void Nox_LatLong_Constructor_WithOutOfRangeLatitude_ThrowsValidationException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
          LatLong.From(100, 0)
        );

        Assert.Equal("Could not create a Nox LatLong type with latitude 100 as it is not in the range -90 to 90 degrees.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_LatLong_Constructor_WithOutOfRangeLongitude_ThrowsValidationException()
    {
        var exception = Assert.Throws<ValidationException>(() => _ =
          LatLong.From(0, 200)
        );

        Assert.Equal("Could not create a Nox LatLong type with longitude 200 as it is not in the range -180 to 180 degrees.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_LatLong_Equality_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From((Latitude: 46.94809, Longitude: 7.44744));

        Assert.Equal(coords1, coords2);
    }

    [Fact]
    public void Nox_LatLong_Equality_WithDifferentContructor_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From((46.94809, 7.44744));

        Assert.Equal(coords1, coords2);
    }

    [Fact]
    public void Nox_LatLong_NotEqual_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From(46.204391, 6.143158);

        Assert.NotEqual(coords1, coords2);
    }

    [Theory]
    [InlineData("en-us","46.948090 7.447440")]
    [InlineData("pt-PT","46,948090 7,447440")]
    public void Nox_LatLong_ToString_ReturnsString(string culture, string expectedResult)
    {
        void Test()
        {
            var coords = LatLong.From(46.94809, 7.44744);
            Assert.Equal(expectedResult, coords.ToString());
        }

        TestUtility.RunInCulture(Test,culture);
    }

    [Fact]
    public void Nox_LatLong_ToString_DMS_ReturnsString()
    {
        var coords = LatLong.From(46.94809, 7.44744);

        var str = coords.ToString("dms");

        Assert.Equal("46°56'53.124\" N 7°26'50.784\" E", coords.ToString("dms"));
    }
}