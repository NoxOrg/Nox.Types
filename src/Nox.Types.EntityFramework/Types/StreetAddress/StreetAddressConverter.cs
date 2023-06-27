using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressConverter : ValueConverter<StreetAddress, (string Line1, string Line2, string Line3, string ZipCode, string City, CountryCode2 CountryCode2)>
{
    public StreetAddressConverter() : base(address => address.Value, addressValue => StreetAddress.From(addressValue))
    {
    }
}