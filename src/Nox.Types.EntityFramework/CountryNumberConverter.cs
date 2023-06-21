using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class CountryNumberConverter : ValueConverter<CountryNumber, short>
{
    public CountryNumberConverter() : base(countryNumber => countryNumber.Value, value => CountryNumber.From(value)) { }
}