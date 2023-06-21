using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class MonthToByteConverter: ValueConverter<Month, byte>
{
    public MonthToByteConverter() : base(month => month.Value, n => Month.From(n)) { }
}