using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Percentage"/> type and value object.
/// </summary>
public sealed class Percentage : ValueObject<float, Percentage>
{
    private readonly PercentageTypeOptions _percentageTypeOptions = new();

    /// <summary>
    /// Validates a <see cref="Percentage"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Percentage"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < _percentageTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Percentage type as value {Value} is less than than the minimum specified value of {_percentageTypeOptions.MinValue}"));
        }

        if (Value > _percentageTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Percentage type a value {Value} is greater than than the maximum specified value of {_percentageTypeOptions.MaxValue}"));
        }

        Value = (float)Math.Round(Value, _percentageTypeOptions.Digits);

        return result;
    }

    public override string ToString()
        => $"{(Value * 100).ToString($"0.{new string('#', _percentageTypeOptions.Digits)}", CultureInfo.InvariantCulture)}%";

    /// <summary>
    /// Returns a string representation of the <see cref="Percentage"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the length value.</param>
    /// <returns>A string representation of the <see cref="Percentage"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)}%";
}
