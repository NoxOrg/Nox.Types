
namespace Nox.Types;

public struct NumberTypeOptions
{
    public static readonly decimal DefaultMinValue = -999999999;
    public static readonly decimal DefaultMaxValue = +999999999;

    public NumberTypeOptions() { }
    public decimal MinValue { get; set; } = DefaultMinValue;
    public decimal MaxValue { get; set; } = DefaultMaxValue;
    public uint DecimalDigits { get; set; } = 0;
}
