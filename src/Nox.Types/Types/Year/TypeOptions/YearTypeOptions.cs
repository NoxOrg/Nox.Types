
namespace Nox.Types;

public class YearTypeOptions
{
    public static readonly ushort DefaultMinValue= 1900;
    public static readonly ushort MaxYearValue = 3000;
    public ushort MinValue { get; set; } = MinYearValue;
    public ushort MaxValue { get; set; } = MaxYearValue;
    public bool AllowFutureOnly { get; set; } = false;
}
