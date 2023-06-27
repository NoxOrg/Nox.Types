using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressConverter : ValueConverter<StreetAddress,
    (int StreetNumber,
    string AddressLine1,
    string AddressLine2,
    string Route,
    string Locality,
    string Neighborhood,
    string AdministrativeArea1,
    string AdministrativeArea2,
    string PostalCode,
    CountryCode2 CountryId)>
{
    public StreetAddressConverter() : base(address => address.Value, addressValue => StreetAddress.From(addressValue))
    {
    }
}