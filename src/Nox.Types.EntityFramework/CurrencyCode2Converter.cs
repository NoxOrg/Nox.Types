namespace Nox.Types.EntityFramework;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public class CurrencyCode2Converter : ValueConverter<CurrencyCode2, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyCode2Converter" /> class.
    /// </summary>
    public CurrencyCode2Converter() : base(currencyCode2 => currencyCode2.Value, currencyCode2 => CurrencyCode2.From(currencyCode2)) { }
}

