using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nox.Types.Tests;

public class NoxDateTimeRangeTests
{
    [Fact]
    public void Nox_DateTimeRange_Constructor_ReturnsSameValue()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(end, dateTimeRange.End);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void Nox_DateTimeRange_Constructor_WithSameStartAndEnd_ReturnsSameValue()
    {
        var start = DateTime.UtcNow;
        var end = start;

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(end, dateTimeRange.End);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void Nox_DateTimeRange_Constructor_WithTimeSpan_ReturnsSameValue()
    {
        var start = DateTime.UtcNow;
        var timeSpan = TimeSpan.FromDays(20);

        var dateTimeRange = DateTimeRange.From(start, timeSpan);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(start + timeSpan, dateTimeRange.End);
        Assert.Equal((start, start + timeSpan), dateTimeRange.Value);
    }

    [Fact]
    public void Nox_DateTimeRange_Constructor_WithInvalidDates_ThrowsValidationException()
    {
        var start = new DateTime(2023, 05, 01);
        var end = new DateTime(2023, 04, 01);
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          DateTimeRange.From(start, end)
        );

        Assert.Equal("Could not create a Nox DateTimeRange type with Start value 5/1/2023 12:00:00 AM and End value 4/1/2023 12:00:00 AM as start of the time range must be the same or after the end of the time range.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_DateTimeRange_Equality_Tests()
    {
        var start = new DateTime(2020, 5, 1);
        var end = new DateTime(2020, 8, 1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, end);

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Nox_DateTimeRange_Equality_WithRegularAndWithTimeSpanConstructors_Tests()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);
        var timeSpan = TimeSpan.FromDays(1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, timeSpan);

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Nox_DateTimeRange_Equality_WithRegularAndWithTupleConstructors_Tests()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From((start, end));

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }


    [Theory]
    [InlineData("2021-01-01", "2021-05-01", "2023-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2021-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2020-01-01", "2021-05-01")]
    public void Nox_DateTimeRange_NonEquality_Tests(string startStr1, string endStr1, string startStr2, string endStr2)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Nox_DateTimeRange_NonEquality_WithRegularAndWithTimeSpanConstructors_Tests()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);
        var timeSpan = TimeSpan.FromDays(3);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, timeSpan);

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Theory]
    [InlineData("2021-01-01", "2021-05-01", "2023-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2021-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2020-01-01", "2021-05-01")]
    public void Nox_DateTimeRange_NonEquality_WithRegularAndWithTupleConstructors_Tests(string startStr1, string endStr1, string startStr2, string endStr2)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From((start2, end2));

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Nox_DateTimeRange_Duration_ReturnsSameValue()
    {
        var start = new DateTime(2023, 01, 01);
        var end = new DateTime(2023, 01, 20);
        var duration = TimeSpan.FromDays(19);

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(duration, dateTimeRange.Duration);
    }

    [Theory]
    [InlineData("2023-01-01")]
    [InlineData("2024-01-01")]
    [InlineData("2023-06-06")]
    public void Nox_DateTimeRange_Contains_ReturnsTrue(string dateTimeStr)
    {
        var dateTime = DateTime.Parse(dateTimeStr);
        var dateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2024, 01, 01));

        Assert.True(dateTimeRange.Contains(dateTime));
    }

    [Theory]
    [InlineData("2022-12-31")]
    [InlineData("2024-01-02")]
    [InlineData("2021-06-06")]
    public void Nox_DateTimeRange_Contains_ReturnsFalse(string dateTimeStr)
    {
        var dateTime = DateTime.Parse(dateTimeStr);
        var dateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2024, 01, 01));

        Assert.False(dateTimeRange.Contains(dateTime));
    }

    [Theory]
    [InlineData("2023-01-01", "2023-06-01", "2023-02-01", "2023-04-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-01-01", "2023-04-01", "2023-02-01", "2023-06-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-02-01", "2023-06-01", "2023-01-01", "2023-04-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-01-01", "2023-02-01", "2023-02-01", "2023-04-01", "2023-02-01", "2023-02-01")]
    public void Nox_DateTimeRange_Intersect_ReturnsIntersectedDateTimeRange(string startStr1, string endStr1, string startStr2, string endStr2, string expectedStartStr, string expectedEndStr)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var expectedStart = DateTime.Parse(expectedStartStr);
        var expectedEnd = DateTime.Parse(expectedEndStr);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        var intersection = dateTimeRange1.Intersect(dateTimeRange2);
        var intersection2 = dateTimeRange2.Intersect(dateTimeRange1);

        Assert.Equal(intersection, intersection2);
        Assert.NotNull(intersection);
        Assert.Equal(expectedStart, intersection.Start);
        Assert.Equal(expectedEnd, intersection.End);
    }

    [Fact]
    public void Nox_DateTimeRange_Intersect_ReturnsNull()
    {
        var start1 = new DateTime(2023, 01, 01);
        var end1 = new DateTime(2023, 02, 01);

        var start2 = new DateTime(2021, 03, 01);
        var end2 = new DateTime(2021, 04, 01);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        var intersection = dateTimeRange1.Intersect(dateTimeRange2);
        var intersection2 = dateTimeRange2.Intersect(dateTimeRange1);

        Assert.Equal(intersection, intersection2);
        Assert.Null(intersection);
    }

    [Theory]
    [InlineData("en-GB", "20/06/2023 10:05:00 - 20/08/2023 10:05:00")]
    [InlineData("en-US", "6/20/2023 10:05:00 AM - 8/20/2023 10:05:00 AM")]
    public void Nox_DateTimeRange_ToString_WithoutParameters_ReturnsString(string culture, string expectedResult)
    {
        void Test()
        {
            var start = new DateTime(2023, 6, 20, 10, 5, 0);
            var end = new DateTime(2023, 8, 20, 10, 5, 0);

            var dateTimeRange = DateTimeRange.From(start, end);
            var dateTimeRangeString = dateTimeRange.ToString();

            Assert.Equal(expectedResult, dateTimeRangeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "d", "20/06/2023 - 20/08/2023")]
    [InlineData("en-US", "d", "6/20/2023 - 8/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00 - 20 Aug 10:05:00")]
    public void Nox_DateTimeRange_ToString_WithFormatParameter_ReturnsString(string culture, string format, string expectedResult)
    {
        void Test()
        {
            var start = new DateTime(2023, 6, 20, 10, 5, 0);
            var end = new DateTime(2023, 8, 20, 10, 5, 0);

            var dateTimeRange = DateTimeRange.From(start, end);
            var dateTimeRangeString = dateTimeRange.ToString(format);

            Assert.Equal(expectedResult, dateTimeRangeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "20/06/2023 10:05:00 - 20/08/2023 10:05:00")]
    [InlineData("en-US", "6/20/2023 10:05:00 AM - 8/20/2023 10:05:00 AM")]
    public void Nox_DateTimeRange_ToString_WithCultureParameter_ReturnsString(string culture, string expectedResult)
    {
        var start = new DateTime(2023, 6, 20, 10, 5, 0);
        var end = new DateTime(2023, 8, 20, 10, 5, 0);

        var dateTimeRange = DateTimeRange.From(start, end);
        var dateTimeRangeString = dateTimeRange.ToString(new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeRangeString);
    }

    [Theory]
    [InlineData("en-GB", "d", "20/06/2023 - 20/08/2023")]
    [InlineData("en-US", "d", "6/20/2023 - 8/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00 - 20 Aug 10:05:00")]
    public void Nox_DateTimeRange_ToString_WithCultureAndFormatParameters_ReturnsString(string culture, string format, string expectedResult)
    {
        var start = new DateTime(2023, 6, 20, 10, 5, 0);
        var end = new DateTime(2023, 8, 20, 10, 5, 0);

        var dateTimeRange = DateTimeRange.From(start, end);
        var dateTimeRangeString = dateTimeRange.ToString(format, new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeRangeString);
    }

    private static void AssertAreEquivalent(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
    {
        Assert.Equal(dateTimeRange1, dateTimeRange2);
        Assert.True(dateTimeRange1.Equals(dateTimeRange2));
        Assert.True(dateTimeRange2.Equals(dateTimeRange1));
        Assert.True(dateTimeRange1 == dateTimeRange2);
        Assert.False(dateTimeRange1 != dateTimeRange2);
    }

    private static void AssertAreNotEquivalent(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
    {
        Assert.NotEqual(dateTimeRange1, dateTimeRange2);
        Assert.False(dateTimeRange1.Equals(dateTimeRange2));
        Assert.False(dateTimeRange2.Equals(dateTimeRange1));
        Assert.False(dateTimeRange1 == dateTimeRange2);
        Assert.True(dateTimeRange1 != dateTimeRange2);
    }
}
