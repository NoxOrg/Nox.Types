using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class AreaToSquareMeterConverter : ValueConverter<Area, double>
{
    public AreaToSquareMeterConverter() : base(area => (double)area.ToSquareMeters(), a => Area.FromSquareMeters(a)) { }
}
public class AreaToSquareFeetConverter : ValueConverter<Area, double>
{
    public AreaToSquareFeetConverter() : base(area => (double)area.ToSquareFeet(), a => Area.FromSquareFeet(a)) { }
}
