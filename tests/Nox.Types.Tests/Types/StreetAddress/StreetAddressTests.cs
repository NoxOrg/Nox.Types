// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class StreetAddressTests
{
    [Theory]
    [InlineData("Line1", "", "", "City", "11111", "UA", "Line1, City, UA 11111")]
    [InlineData("", "Line2", "", "City", "11111", "UA", "Line2, City, UA 11111")]
    [InlineData("", "", "Line3", "City", "11111", "UA", "Line3, City, UA 11111")]
    [InlineData("Line1", "Line2", "Line3", "City", "11111", "UA", "Line1 Line2 Line3, City, UA 11111")]
    public void Nox_StreetAddress_AddressString_ReturnsValidAddress(
        string line1,
        string line2,
        string line3,
        string city,
        string zipCode,
        string countryCode,
        string expectedAddress)
    {
        var countryCode2 = CountryCode2.From(countryCode);
        var address = StreetAddress.From((line1, line2, line3, zipCode, city, countryCode2));

        Assert.Equal(expectedAddress, address.ToString());
    }

    [Fact]
    public void Nox_StreetAddress_WrongZipCode_Throws()
    {
        var zipCode = "1abcd11";
        var countryCode2 = CountryCode2.From("CH");

        var exception = Assert.Throws<TypeValidationException>(() => StreetAddress.From(("Line1", string.Empty, string.Empty, zipCode, "Test", countryCode2)));

        Assert.Contains(exception.Errors, t => t.Variable == "ZipCode");
    }
}