using System.Linq;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="StreetAddress"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class StreetAddress : ValueObject<(string Line1, string Line2, string Line3, string ZipCode, string City, CountryCode2 CountryCode2), StreetAddress>
{
    private readonly Regex _zipCodeRegex = new("^\\d{5}(?:[-\\s]\\d{4})?$");

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        var zipCodeMatch = _zipCodeRegex.IsMatch(Value.ZipCode);
        if (!zipCodeMatch)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.ZipCode), "ZipCode value doesn't match valid zip code pattern."));
        }

        var countryValidation = Value.CountryCode2.Validate();
        result.Errors.AddRange(countryValidation.Errors);

        return result;
    }

    public override string ToString()
    {
        var addressLine = string.Join(" ", new[]
            { Value.Line1, Value.Line2, Value.Line3 }
            .Where(x => !string.IsNullOrWhiteSpace(x)));

        return $"{addressLine}, {Value.City}, {Value.CountryCode2} {Value.ZipCode}";
    }
}