using System;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public sealed class CurrencyCode2 : ValueObject<string, CurrencyCode2>
{
    private const string ThreeLettersCurrencyCode = @"^[A-Z]{3}$";

    /// <summary>
    /// Validates the <see cref="CurrencyCode2"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CurrencyCode2"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!Regex.IsMatch(Value, ThreeLettersCurrencyCode) && !Enum.TryParse<CurrencyCode>(Value, out _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CurrencyCode2 type with unsupported value '{Value}'."));
        }

        return result;
    }
}
