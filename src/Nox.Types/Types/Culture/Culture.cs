using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public class Culture : ValueObject<string, Culture>
{
    private const string TwoLetterCultureCode = @"^[a-z]{2}$";
    private const string FiveLetterCultureCode = @"^[a-z]{2}-[A-Z]{2}$";
    private const string TenLetterCultureCode = @"^[a-z]{2}-[A-Z]{2}-[A-Z][a-z]{3}$";

    /// <summary>
    /// Validates the <see cref="Culture"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Culture"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();
        
        if (!Regex.IsMatch(Value, TwoLetterCultureCode) && !Regex.IsMatch(Value, FiveLetterCultureCode) && !Regex.IsMatch(Value, TenLetterCultureCode))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Culture type with unsupported value '{Value}'."));
        }

        return result;
    }

   
}
