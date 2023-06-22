using System;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public sealed class CurrencyCode3 : ValueObject<string, CurrencyCode3>
{
    private const string ThreeLettersCurrencyCode = @"^[A-Z]{3}$";

    /// <summary>
    /// Validates the <see cref="CurrencyCode3"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CurrencyCode3"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!Regex.IsMatch(Value, ThreeLettersCurrencyCode) && !Enum.TryParse<CurrencyCode>(Value, out _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CurrencyCode3 type with unsupported value '{Value}'."));
        }

        return result;
    }
}
