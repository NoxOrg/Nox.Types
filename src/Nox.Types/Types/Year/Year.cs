namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Year"/> type and value object.
/// </summary>
public sealed class Year : ValueObject<ushort, Year>
{
    /// <summary>
    /// The minimum valid year value.
    /// </summary>
    private const ushort MinYearValue = 1;

    /// <summary>
    /// The maximum valid year value.
    /// </summary>
    private const ushort MaxYearValue = 9999;

    /// <summary>
    /// Validates the <see cref="Year"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Year"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value is < MinYearValue or > MaxYearValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Year type with unsupported value '{Value}'. The value must be between {MinYearValue} and {MaxYearValue}."));
        }
        return result;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString("0000");
    }
}