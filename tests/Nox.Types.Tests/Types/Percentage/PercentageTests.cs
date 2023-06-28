namespace Nox.Types.Tests.Types;

public class PercentageTests
{
    [Fact]
    public void Percentage_Constructor_ReturnsSameValue()
    {
        var testPercentage = 0.5f;

        var number = Percentage.From(testPercentage);

        Assert.Equal(testPercentage, number.Value);
    }

    [Fact]
    public void Percentage_Constructor_ThrowsException_WhenValueExceedsMaxAllowed()
    {
        var testPercentage = 3.2f;

        Assert.Throws<TypeValidationException>(() => _ =
            Percentage.From(testPercentage)
        );
    }

    [Fact]
    public void Percentage_Constructor_ThrowsException_WhenValueIsLessThanMinAllowed()
    {
        var testPercentage = -0.3f;

        Assert.Throws<TypeValidationException>(() => _ =
            Percentage.From(testPercentage)
        );
    }

    [Fact]
    public void Percentage_Constructor_RoundsFloatValues_WhenConstructedWithFloatInput()
    {
        var testPercentage = 0.4f;

        var percentage = Percentage.From(testPercentage);

        Assert.Equal(0.4, percentage.Value);
    }

    [Fact]
    public void Percentage_ToString_Returns_Value()
    {
        void Test()
        {
            var pecentageValue = 0.45f;

            var percentage = Percentage.From(pecentageValue);

            var percentageAsString = percentage.ToString();

            Assert.Equal("45%", percentageAsString);
        }

        TestUtility.RunInInvariantCulture(Test);
    }
}