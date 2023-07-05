using Nox.Types.Tests.Types;

namespace Nox.Types.Tests;
public class CurrencyCode3Tests
{
    [Theory]
    [ClassData(typeof(CurrencyCodeData))]
    public void CurrencyCode3_Constructor_ReturnsSameValue_AllCurrencies(string currencyCode3String)
    {
        var currencyCode3 = CurrencyCode3.From(currencyCode3String);

        Assert.Equal(currencyCode3String, currencyCode3.Value);
    }

    [Fact]
    public void CurrencyCode3_Constructor_WithUnsupportedCurrencyCode3_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          CurrencyCode3.From("ABC")
        );

        Assert.Equal("Could not create a Nox CurrencyCode3 type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void CurrencyCode3_Equality_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("USD");

        var currencyCode3_2 = CurrencyCode3.From("USD");

        Assert.Equal(currencyCode3_1, currencyCode3_2);
    }

    [Fact]
    public void CurrencyCode3_NotEqual_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("RWF");

        var currencyCode3_2 = CurrencyCode3.From("SHP");

        Assert.NotEqual(currencyCode3_1, currencyCode3_2);
    }

    [Fact]
    public void CurrencyCode3_ToString_ReturnsString()
    {
        var currencyCode3 = CurrencyCode3.From("USD");

        Assert.Equal("USD", currencyCode3.ToString());
    }
}

