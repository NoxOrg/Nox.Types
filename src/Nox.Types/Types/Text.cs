
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Text"/> type and value object. 
/// </summary>
public class Text : ValueObject, INoxType
{
    /// <summary>
    /// The string value of the <see cref="Text"/> object.
    /// </summary>
    public string Value => _value;
    private readonly string _value;

    /// <summary>
    /// Whether the text object may contain Unicode characters or Ascii characters only.
    /// </summary>
    public bool IsUnicode => _isUnicode;
    private readonly bool _isUnicode;

    /// <summary>
    /// The minimum length allowed for the <see cref="Text"/> object.
    /// </summary>
    public int MinLength => _minLength;
    private readonly int _minLength;

    /// <summary>
    /// The maximum length allowed for the <see cref="Text"/> object.
    /// </summary>
    public int MaxLength => _maxLength;
    private readonly int _maxLength;

    /// <summary>
    /// The casing allowed by the <see cref="Text"/> object. This is automatically applied during construction.
    /// </summary>
    public TextTypeCasing Casing => _casing;
    private readonly TextTypeCasing _casing;

    /// <summary>
    /// Whether the <see cref="Text"/> object typically contains multiline text or not.
    /// </summary>
    public bool IsMultiLine => _isMultiLine;
    private readonly bool _isMultiLine;

    /// <summary>
    /// The default .Net <see cref="Type"/> to store the <see cref="Value"/> of the <see cref="Text"/> type.
    /// </summary>
    public Type DotNetType() => typeof(string);

    /// <summary>
    /// Initializes a new instance of the <see cref="Text"/> class.
    /// </summary>
    /// <param name="value">The string to initialse the text oject with.</param>
    /// <param name="isUnicode">Whether the string can contain Unicode characters or not.</param>
    /// <param name="minLength">The mimimum length that the text object allows.</param>
    /// <param name="maxLength">The maximum length that the text object allows.</param>
    /// <param name="casing">The <see cref="TextTypeCasing"/> that the text object will contain.</param>
    /// <param name="isMultiLine">Specifies whether this text object typically contains multi-line information or not.</param>
    /// <exception cref="ArgumentException">Thrown when the text is set to an invalid value based on isUnicode, minLength or maxLength.</exception>
    public Text(
        string value,
        bool isUnicode = true,
        int minLength = 0,
        int maxLength = 511,
        TextTypeCasing casing = TextTypeCasing.Normal,
        bool isMultiLine = false)
    {

        if (!isUnicode && value.Any(c => c > 255))
        {
            throw new ArgumentException($"Could not create a non-UniCode Nox Text type that contains Unicode characters '{new string(value.Where( c => c >255 ).ToArray())}'");
        }

        if (value.Length < minLength)
        {
            throw new ArgumentException($"Could not create a Nox Text type that is {value.Length} characters long and shorter than the minumum specified length of {minLength}");
        }

        if (value.Length > maxLength)
        {
            throw new ArgumentException($"Could not create a Nox Text type that is {value.Length} characters long and longer than the maximum specified length of {maxLength}");
        }

        _value = casing switch
        {
            TextTypeCasing.Normal => value,
            TextTypeCasing.Upper => value.ToUpperInvariant(),
            TextTypeCasing.Lower => value.ToLowerInvariant(),
            _ => throw new NotImplementedException(),
        };

        _isUnicode = isUnicode;
        _minLength = minLength;   
        _maxLength = maxLength;
        _casing = casing;
        _isMultiLine = isMultiLine;
    }

    /// <summary>
    /// Gets the value property of the text class for equality comparison.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{object}"/> containing the <see cref="Text"/> object's <see cref="Value"/> property.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }

    /// <summary>
    /// Converts the <see cref="Text"/> to its <see cref="string"/> representation.
    /// </summary>
    /// <returns>A <see cref="string"/> containing the <see cref="Text"/> object's <see cref="Value"/> property.</returns>
    public override string ToString()
    {
        return _value;
    }
}
