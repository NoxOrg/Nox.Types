using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class DistanceToKilometerConverter : ValueConverter<Distance, double>
{
    public DistanceToKilometerConverter() : base(area => (double)area.ToKilometers(), d => Distance.FromKilometers(d)) { }
}
public class DistanceToMilesConverter : ValueConverter<Distance, double>
{
    public DistanceToMilesConverter() : base(area => (double)area.ToMiles(), d => Distance.FromMiles(d)) { }
}
