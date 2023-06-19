namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public class Culture : ValueObject<(string Code, string DisplayName), Culture>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Culture"/> class with empty values.
    /// </summary>
    public Culture()
    {
        Value = (Code: string.Empty, DisplayName: string.Empty);
    } 

    /// <summary>
    /// Gets the culture code.
    /// </summary>
    public string Code => Value.Code;

    /// <summary>
    /// Gets the display name of the culture.
    /// </summary>
    public string DisplayName => Value.DisplayName;

    /// <summary>
    /// Creates a new instance of the <see cref="Culture"/> class with the specified code and display name.
    /// </summary>
    /// <param name="code">The culture code.</param>
    /// <param name="displayName">The display name of the culture.</param>
    /// <returns>A new instance of the <see cref="Culture"/> class.</returns>
    public static Culture From(string code, string displayName)
        => From((code, displayName));

    /// <summary>
    /// Validates the <see cref="Culture"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Culture"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (string.IsNullOrWhiteSpace(Value.Code))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Culture type with code {Value.Code} as it is null or empty"));
        }
        else if (Value.Code.Length != 5)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Culture type with code {Value.Code} as it is not 5 characters long"));
        }
       
        if (string.IsNullOrWhiteSpace(Value.DisplayName))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Culture type with display name {Value.DisplayName} as it is null or empty"));
        }

        return result;
    }

    /// <summary>
    /// Returns the string representation of the <see cref="Culture"/> object.
    /// </summary>
    /// <returns>The culture code.</returns>
    public override string ToString()
    {
        return $"{Value.Code}";
    }
}
