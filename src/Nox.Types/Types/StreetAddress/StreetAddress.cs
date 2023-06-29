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

    public int StreetNumber
    {
        get => Value.StreetNumber;
        private set => Value =
            (StreetNumber: value,
             Value.AddressLine1,
             Value.AddressLine2,
             Value.Route,
             Value.Locality,
             Value.Neighborhood,
             Value.AdministrativeArea1,
             Value.AdministrativeArea2,
             Value.PostalCode,
             Value.CountryId);
    }

    public string AddressLine1
    {
        get => Value.AddressLine1;
        private set => Value =
            (Value.StreetNumber,
             AddressLine1: value,
             Value.AddressLine2,
             Value.Route,
             Value.Locality,
             Value.Neighborhood,
             Value.AdministrativeArea1,
             Value.AdministrativeArea2,
             Value.PostalCode,
             Value.CountryId);
    }

    public string AddressLine2
    {
        get => Value.AddressLine2;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            AddressLine2: value,
            Value.Route,
            Value.Locality,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            Value.PostalCode,
            Value.CountryId);
    }

    public string Route
    {
        get => Value.Route;
        private set => Value =
            (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Route: value,
            Value.Locality,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            Value.PostalCode,
            Value.CountryId);
    }

    public string Locality
    {
        get => Value.Locality;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Locality: value,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            Value.PostalCode,
            Value.CountryId);
    }

    public string Neighborhood
    {
        get => Value.Neighborhood;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Value.Locality,
            Neighborhood: value,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            Value.PostalCode,
            Value.CountryId);
    }

    public string AdministrativeArea1
    {
        get => Value.AdministrativeArea1;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Value.Locality,
            Value.Neighborhood,
            AdministrativeArea1: value,
            Value.AdministrativeArea2,
            Value.PostalCode,
            Value.CountryId);
    }

    public string AdministrativeArea2
    {
        get => Value.AdministrativeArea2;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Value.Locality,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            AdministrativeArea2: value,
            Value.PostalCode,
            Value.CountryId);
    }

    public string PostalCode
    {
        get => Value.PostalCode;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Value.Locality,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            PostalCode: value,
            Value.CountryId);
    }

    public CountryCode2 CountryId
    {
        get => Value.CountryId;
        private set => Value =
           (Value.StreetNumber,
            Value.AddressLine1,
            Value.AddressLine2,
            Value.Route,
            Value.Locality,
            Value.Neighborhood,
            Value.AdministrativeArea1,
            Value.AdministrativeArea2,
            Value.PostalCode,
            CountryId: value);
    }

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