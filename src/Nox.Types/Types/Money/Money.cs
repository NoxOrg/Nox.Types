using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using FluentValidation.Results;

namespace Nox.Types;

/// <summary>
/// Represents a value object for representing monetary values.
/// </summary>
[Serializable]
public sealed class Money : ValueObject<decimal, Money>
{
    /// <summary>
    ///  Gets the monetary value.
    /// </summary>
    public decimal Amount => Value;

    /// <summary>
    /// Gets the currency code of the money value.
    /// </summary>
    public CurrencyCode CurrencyCode { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class with default values.
    /// </summary>
    public Money()
    {
        Value = 0;
        CurrencyCode = CurrencyCode.USD;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class with the specified values.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <param name="currencyCode">The currency code enum.</param>
    private Money(decimal value, CurrencyCode currencyCode)
    {
        Value = value;
        CurrencyCode = currencyCode;
    }
    
    /// <summary>
    /// Creates a new instance of the <see cref="Money"/> class with the specified values.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <returns>A new instance of the <see cref="Money"/> class.</returns>
    public new static Money From(decimal value)
    {
        return new Money(value, CurrencyCode.USD);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Money"/> class with the specified values.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <param name="currencyCode">The currency code enum.</param>
    /// <returns>A new instance of the <see cref="Money"/> class.</returns>
    public static Money From(decimal value, CurrencyCode currencyCode)
    {
        return new Money(value, currencyCode);
    }

    /// <summary>
    /// Returns properties that are used to determine equality between two <see cref="Money"/> objects.
    /// </summary>
    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Amount), Amount);
        yield return new KeyValuePair<string, object>(nameof(CurrencyCode), CurrencyCode);
    }

    public override string ToString()
    {
        return ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object using the specified <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="amountFormat">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the amount formatted using the specified format and Invariant culture .</returns>
    public string ToString(string amountFormat)
    {
        return ToString(CultureInfo.InvariantCulture, amountFormat);
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object using the specified <paramref name="cultureInfo"/> and <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="cultureInfo">The culture-specific information used to format the amount.</param>
    /// <param name="amountFormat">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the amount formatted using the specified culture and format.</returns>
    public string ToString(CultureInfo cultureInfo, string amountFormat = "G")
    {
        if (cultureInfo == null) throw new ArgumentNullException(nameof(cultureInfo));
        if (amountFormat == null) throw new ArgumentNullException(nameof(amountFormat));
        return $"{Amount.ToString(amountFormat, cultureInfo)}";
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object with the currency symbol using the Invariant culture and <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="amountFormat">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the currency symbol and the amount formatted using the specified format and Invariant culture.</returns>
    public string ToStringWithSymbol(string amountFormat = "N2")
    {
        return ToStringWithSymbol(CultureInfo.InvariantCulture, amountFormat);
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object with the currency symbol using the specified <paramref name="cultureInfo"/> and <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="cultureInfo">The culture-specific information used to format the amount.</param>
    /// <param name="amountFormat">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the currency symbol and the amount formatted using the specified culture and format.</returns>
    public string ToStringWithSymbol(CultureInfo cultureInfo, string amountFormat = "N2")
    {
        if (cultureInfo == null) throw new ArgumentNullException(nameof(cultureInfo));
        if (amountFormat == null) throw new ArgumentNullException(nameof(amountFormat));
        return $"{CurrencyConverter.GetCurrencySymbol(CurrencyCode)}{Amount.ToString(amountFormat, cultureInfo)}";
    }
}