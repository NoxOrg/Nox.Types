namespace Nox.Types.Tests;
public class NoxCurrencyCode2Tests
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
    public void Nox_CurrencyCode2_Constructor_ReturnsSameValue_AllCurrencies(string currencyCode2String)
    {
        var currencyCode2 = CurrencyCode2.From(currencyCode2String);

        Assert.Equal(currencyCode2String, currencyCode2.Value);
    }

    [Fact]
    public void Nox_CurrencyCode2_Constructor_WithUnsupportedCurrencyCode2_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          CurrencyCode2.From("ABC")
        );

        Assert.Equal("Could not create a Nox CurrencyCode2 type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_CurrencyCode2_Equality_Tests()
    {
        var currencyCode2_1 = CurrencyCode2.From("USD");

        var currencyCode2_2 = CurrencyCode2.From("USD");

        Assert.Equal(currencyCode2_1, currencyCode2_2);
    }

    [Fact]
    public void Nox_CurrencyCode2_NotEqual_Tests()
    {
        var currencyCode2_1 = CurrencyCode2.From("RWF");

        var currencyCode2_2 = CurrencyCode2.From("SHP");

        Assert.NotEqual(currencyCode2_1, currencyCode2_2);
    }

    [Fact]
    public void Nox_CurrencyCode2_ToString_ReturnsString()
    {
        var currencyCode2 = CountryCode2.From("USD");

        Assert.Equal("USD", currencyCode2.ToString());
    }
}

