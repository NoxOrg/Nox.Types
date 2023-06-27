using System.Linq;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="StreetAddress"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class StreetAddress : ValueObject<
    (int StreetNumber,
    string AddressLine1,
    string AddressLine2,
    string Route,
    string Locality,
    string Neighborhood,
    string AdministrativeArea1,
    string AdministrativeArea2,
    string PostalCode,
    CountryCode2 CountryId), StreetAddress>
{
    private readonly Regex _postalCodeRegex = new("^\\d{5}(?:[-\\s]\\d{4})?$");

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        var zipCodeMatch = _postalCodeRegex.IsMatch(Value.PostalCode);
        if (!zipCodeMatch)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PostalCode), "PostalCode value doesn't match valid postal code pattern."));
        }

        var countryValidation = Value.CountryId.Validate();
        result.Errors.AddRange(countryValidation.Errors);

        return result;
    }

    public override string ToString()
    {
        var addressLine = string.Join(" ", new[]
            { Value.AddressLine1, Value.AddressLine2}
            .Where(x => !string.IsNullOrWhiteSpace(x)));

        if (!string.IsNullOrWhiteSpace(addressLine))
        {
            addressLine += ", ";
        }

        return $"{addressLine}{Value.Locality}, {Value.CountryId} {Value.PostalCode}";
    }
}