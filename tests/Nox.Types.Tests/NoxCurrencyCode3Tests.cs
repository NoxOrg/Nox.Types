namespace Nox.Types.Tests;
public class NoxCurrencyCode3Tests
{
    [InlineData("AED")]
    [InlineData("AFN")]
    [InlineData("ALL")]
    [InlineData("AMD")]
    [InlineData("ANG")]
    [InlineData("AOA")]
    [InlineData("ARS")]
    [InlineData("AUD")]
    [InlineData("AWG")]
    [InlineData("AZN")]
    [InlineData("BAM")]
    [InlineData("BBD")]
    [InlineData("BDT")]
    [InlineData("BGN")]
    [InlineData("BHD")]
    [InlineData("BIF")]
    [InlineData("BMD")]
    [InlineData("BND")]
    [InlineData("BOB")]
    [InlineData("BRL")]
    [InlineData("BSD")]
    [InlineData("BTC")]
    [InlineData("BTN")]
    [InlineData("BWP")]
    [InlineData("BYR")]
    [InlineData("BYN")]
    [InlineData("BZD")]
    [InlineData("CAD")]
    [InlineData("CDF")]
    [InlineData("CHF")]
    [InlineData("CLP")]
    [InlineData("CNY")]
    [InlineData("COP")]
    [InlineData("CRC")]
    [InlineData("CUC")]
    [InlineData("CUP")]
    [InlineData("CVE")]
    [InlineData("CZK")]
    [InlineData("DJF")]
    [InlineData("DKK")]
    [InlineData("DOP")]
    [InlineData("DZD")]
    [InlineData("EGP")]
    [InlineData("ERN")]
    [InlineData("ETB")]
    [InlineData("EUR")]
    [InlineData("FJD")]
    [InlineData("FKP")]
    [InlineData("GBP")]
    [InlineData("GEL")]
    [InlineData("GHS")]
    [InlineData("GIP")]
    [InlineData("GMD")]
    [InlineData("GNF")]
    [InlineData("GTQ")]
    [InlineData("GYD")]
    [InlineData("HKD")]
    [InlineData("HNL")]
    [InlineData("HRK")]
    [InlineData("HTG")]
    [InlineData("HUF")]
    [InlineData("IDR")]
    [InlineData("ILS")]
    [InlineData("INR")]
    [InlineData("IQD")]
    [InlineData("IRR")]
    [InlineData("ISK")]
    [InlineData("JMD")]
    [InlineData("JOD")]
    [InlineData("JPY")]
    [InlineData("KES")]
    [InlineData("KGS")]
    [InlineData("KHR")]
    [InlineData("KMF")]
    [InlineData("KPW")]
    [InlineData("KRW")]
    [InlineData("KWD")]
    [InlineData("KYD")]
    [InlineData("KZT")]
    [InlineData("LAK")]
    [InlineData("LBP")]
    [InlineData("LKR")]
    [InlineData("LRD")]
    [InlineData("LSL")]
    [InlineData("LYD")]
    [InlineData("MAD")]
    [InlineData("MDL")]
    [InlineData("MGA")]
    [InlineData("MKD")]
    [InlineData("MMK")]
    [InlineData("MNT")]
    [InlineData("MOP")]
    [InlineData("MRO")]
    [InlineData("MTL")]
    [InlineData("MUR")]
    [InlineData("MVR")]
    [InlineData("MWK")]
    [InlineData("MXN")]
    [InlineData("MYR")]
    [InlineData("MZN")]
    [InlineData("NAD")]
    [InlineData("NGN")]
    [InlineData("NIO")]
    [InlineData("NOK")]
    [InlineData("NPR")]
    [InlineData("NZD")]
    [InlineData("OMR")]
    [InlineData("PAB")]
    [InlineData("PEN")]
    [InlineData("PGK")]
    [InlineData("PHP")]
    [InlineData("PKR")]
    [InlineData("PLN")]
    [InlineData("PYG")]
    [InlineData("QAR")]
    [InlineData("RON")]
    [InlineData("RSD")]
    [InlineData("RUB")]
    [InlineData("RWF")]
    [InlineData("SAR")]
    [InlineData("SBD")]
    [InlineData("SCR")]
    [InlineData("SDD")]
    [InlineData("SDG")]
    [InlineData("SEK")]
    [InlineData("SGD")]
    [InlineData("SHP")]
    [InlineData("SLL")]
    [InlineData("SOS")]
    [InlineData("SRD")]
    [InlineData("STD")]
    [Theory]
    public void Nox_CurrencyCode3_Constructor_ReturnsSameValue_AllCurrencies(string currencyCode3String)
    {
        var currencyCode3 = CurrencyCode3.From(currencyCode3String);

        Assert.Equal(currencyCode3String, currencyCode3.Value);
    }

    [Fact]
    public void Nox_CurrencyCode3_Constructor_WithUnsupportedCurrencyCode3_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          CurrencyCode3.From("ABC")
        );

        Assert.Equal("Could not create a Nox CurrencyCode3 type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_CurrencyCode3_Equality_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("USD");

        var currencyCode3_2 = CurrencyCode3.From("USD");

        Assert.Equal(currencyCode3_1, currencyCode3_2);
    }

    [Fact]
    public void Nox_CurrencyCode3_NotEqual_Tests()
    {
        var currencyCode3_1 = CurrencyCode3.From("RWF");

        var currencyCode3_2 = CurrencyCode3.From("SHP");

        Assert.NotEqual(currencyCode3_1, currencyCode3_2);
    }

    [Fact]
    public void Nox_CurrencyCode3_ToString_ReturnsString()
    {
        var currencyCode3 = CountryCode2.From("USD");

        Assert.Equal("USD", currencyCode3.ToString());
    }
}

