// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class StreetAddressTests
{
    [Theory]
    [InlineData(5, "Line1", "", "Locality", "11111", "UA", "", "Line1, Locality, 11111, UA")]
    [InlineData(5, "", "Line2", "Locality", "11111", "UA", "", "Line2, Locality, 11111, UA")]
    [InlineData(5, "", "", "Locality", "11111", "UA", "", "Locality, 11111, UA")]
    [InlineData(5, "Line1", "Line2", "Locality", "11111", "UA", "KH", "Line1 Line2, Locality, KH 11111, UA")]
    public void Nox_StreetAddress_AddressString_ReturnsValidAddress(
        int streetNumber,
        string addressLine1,
        string addressLine2,
        string locality,
        string postalCode,
        string countryCode,
        string administrativeArea1,
        string expectedAddress)
    {
        var countryCode2 = CountryCode2.From(countryCode);
        var address = StreetAddress.From(
            (streetNumber,
            addressLine1,
            addressLine2,
            "Route",
            locality,
            string.Empty,
            administrativeArea1,
            string.Empty,
            postalCode,
            countryCode2));

        Assert.Equal(expectedAddress, address.ToString());
    }

    [Fact]
    public void Nox_StreetAddress_WrongZipCode_Throws()
    {
        var postalCode = "1abcd11";
        var countryCode2 = CountryCode2.From("CH");

        var exception = Assert.Throws<TypeValidationException>(() => StreetAddress.From((
            1,
            "Line1",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            postalCode,
            "Test", countryCode2)
        ));

        Assert.Contains(exception.Errors, t => t.Variable == "PostalCode");
    }
}