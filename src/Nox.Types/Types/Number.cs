
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Number"/> type and value object. 
/// </summary>
public class Number : ValueObject<decimal>, INoxType
{

    /// <summary>
    /// The minimum length allowed for the <see cref="Text"/> object.
    /// </summary>
    public int DecimalDigits => _decimalDigits;
    private readonly int _decimalDigits;

    /// <summary>
    /// The minimum length allowed for the <see cref="Text"/> object.
    /// </summary>
    public decimal MinValue => _minValue;
    private readonly decimal _minValue;

    /// <summary>
    /// The maximum length allowed for the <see cref="Text"/> object.
    /// </summary>
    public decimal MaxValue => _maxValue;
    private readonly decimal _maxValue;

    /// <summary>
    /// The default .Net <see cref="Type"/> to store the <see cref="Value"/> of the <see cref="Text"/> type.
    /// </summary>
    public Type DotNetType() =>
          // if
        (_decimalDigits == 0)
        ? // then
              // if
            (_value > int.MaxValue)
            ? // then
                  // if
                (_value > long.MaxValue)
                ? // then
                    typeof(decimal)
                : // else
                    typeof(long)
            : // else
                typeof(int)
        : // else
        typeof(decimal);

    /// <summary>
    /// Returns the .Net numeric typed value of the <see cref="Number"/>.
    /// </summary>
    /// <returns></returns>
    public object DotNetValue() =>
          // if
        (_decimalDigits == 0)
        ? // then
              // if
            (_value > int.MaxValue)
            ? // then
                  // if
                (_value > long.MaxValue)
                ? // then
                    _value
                : // else
                    (long)_value
            : // else
                (int)_value
        : // else
        _value;
    

    /// <summary>
    /// Initializes a new instance of the <see cref="Text"/> class.
    /// </summary>
    /// <param name="value">The string to initialse the text oject with.</param>
    /// <param name="isUnicode">Whether the string can contain Unicode characters or not.</param>
    /// <param name="minValue">The mimimum length that the text object allows.</param>
    /// <param name="maxValue">The maximum length that the text object allows.</param>
    /// <param name="casing">The <see cref="TextTypeCasing"/> that the text object will contain.</param>
    /// <param name="isMultiLine">Specifies whether this text object typically contains multi-line information or not.</param>
    /// <exception cref="ArgumentException">Thrown when the text is set to an invalid value based on isUnicode, minLength or maxLength.</exception>
    public Number(
        decimal value,
        int decimalDigits = 0,
        decimal minValue = -999999999,
        decimal maxValue = 999999999) : base(value)
    {

        if (value < minValue)
        {
            throw new ArgumentException($"Could not create a Nox Number type equal to {value} that is less than than the minumum specified value of {minValue}");
        }

        if (value > maxValue)
        {
            throw new ArgumentException($"Could not create a Nox Number type equal to {value} that is more than the maximum specified value of {maxValue}");
        }

        if (decimalDigits == 0 && value <= long.MaxValue)
        {
            value = (long)value;
        }

        _minValue = minValue;
        _maxValue = maxValue;
        _decimalDigits = decimalDigits;
    }

    /// <summary>
    /// Gets the value property of the text class for equality comparison.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{decimal}"/> containing the <see cref="Text"/> object's <see cref="Value"/> property.</returns>
    protected override IEnumerable<decimal> GetEqualityComponents()
    {
        yield return _value;
    }

    /// <summary>
    /// Converts the <see cref="Text"/> to its <see cref="string"/> representation.
    /// </summary>
    /// <returns>A <see cref="string"/> containing the <see cref="Text"/> object's <see cref="Value"/> property.</returns>
    public override string ToString()
    {
        return DotNetType().Name switch
        {
            "int" => ((int)_value).ToString(),
            "long" => ((long)_value).ToString(),
            "decimal" => _value.ToString().TrimEnd('0').TrimEnd('.'),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Adds two Nox <see cref="Number"/>s.
    /// </summary>
    /// <param name="number1">The number to add to.</param>
    /// <param name="number2">The number to add.</param>
    /// <returns></returns>
    public static Number operator +(Number number1, Number number2)
    {
        var number = new Number(
            number1.Value + number2.Value,
            Math.Max(number1.DecimalDigits, number2.DecimalDigits),
            Math.Min(number1.MinValue, number2.MinValue),
            Math.Max(number1.MaxValue, number2.MaxValue)
        );

        return number;
    }

    /// <summary>
    /// Subtracts one Nox <see cref="Number"/> from another.
    /// </summary>
    /// <param name="number1">The number to subtract from.</param>
    /// <param name="number2">The number to subtract.</param>
    /// <returns></returns>
    public static Number operator -(Number number1, Number number2)
    {
        var number = new Number(
            number1.Value - number2.Value,
            Math.Max(number1.DecimalDigits, number2.DecimalDigits),
            Math.Min(number1.MinValue, number2.MinValue),
            Math.Max(number1.MaxValue, number2.MaxValue)
        );

        return number;
    }

    // TODO: Implement *, /, +=, -=. /=, *=

}
