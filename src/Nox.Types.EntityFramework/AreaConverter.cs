using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class AreaConverter : ValueConverter<Area, double>
{
    public AreaConverter() : base(area => area.ValueInSquareMeters, val => Area.FromSquareMeters(val)) { }
}