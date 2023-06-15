using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class AreaConverter : ValueConverter<Area, double>
{
    public AreaConverter() : base(area => area.ToSquareMeters(), val => Area.FromSquareMeters(val)) { }
}