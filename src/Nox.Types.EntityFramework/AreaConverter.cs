using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class AreaToDoubleConverter : ValueConverter<Area, double>
{
    public AreaToDoubleConverter() : base(area => (double)area.ToSquareMeters(), a => Area.From(a)) { }
}

public class AreaToDecimalConverter : ValueConverter<Area, decimal>
{
    public AreaToDecimalConverter() : base(area => (decimal)area.ToSquareMeters(), a => Area.From(a)) { }
}

public class AreaToByteConverter : ValueConverter<Area, byte>
{
    public AreaToByteConverter() : base(area => (byte)area.ToSquareMeters(), a => Area.From(a)) { }
}

public class AreaToShortConverter : ValueConverter<Area, short>
{
    public AreaToShortConverter() : base(area => (short)area.ToSquareMeters(), a => Area.From(a)) { }
}

public class AreaToInt32Converter : ValueConverter<Area, int>
{
    public AreaToInt32Converter() : base(area => (int)area.ToSquareMeters(), a => Area.From(a)) { }
}

public class AreaToInt64Converter : ValueConverter<Area, long>
{
    public AreaToInt64Converter() : base(area => (long)area.ToSquareMeters(), a => Area.From(a)) { }
}