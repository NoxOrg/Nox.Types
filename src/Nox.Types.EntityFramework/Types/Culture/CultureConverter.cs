using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class CultureConverter : ValueConverter<Culture, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CultureConverter" /> class.
    /// </summary>
    public CultureConverter() : base(culture => culture.Value, cultureValue => Culture.From(cultureValue))
    {
    }
}
