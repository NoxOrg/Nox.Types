using System;
using System.Linq;

namespace Nox.Types;

internal class AreaUnitConverter
{
    private static readonly IAreaUnitConverter[] _converters =
    {
        new SquareMetersToSquareFeetConverter(),
        new SquareFeetToSquareMetersConverter(),
    };

    private readonly Area _area;

    public AreaUnitConverter(Area area)
    {
        _area = area;
    }

    public QuantityValue To(AreaTypeUnit unit)
        => _area.Unit == unit ? _area.Value : ConvertTo(unit);

    private QuantityValue ConvertTo(AreaTypeUnit unit)
        => ResolveUnitConverter(unit).Convert(_area.Value);

    private IAreaUnitConverter ResolveUnitConverter(AreaTypeUnit unit)
        => _converters.FirstOrDefault(x => x.InputUnit == _area.Unit && x.OutputUnit == unit) 
        ?? throw new NotImplementedException();
}

internal interface IAreaUnitConverter
{
    AreaTypeUnit InputUnit { get; }
    AreaTypeUnit OutputUnit { get; }

    QuantityValue Convert(QuantityValue value);
}

internal class SquareMetersToSquareFeetConverter : IAreaUnitConverter
{
    public AreaTypeUnit InputUnit => AreaTypeUnit.SquareMeter;

    public AreaTypeUnit OutputUnit => AreaTypeUnit.SquareFoot;

    public QuantityValue Convert(QuantityValue value) => 10.7639104 * value;
}

internal class SquareFeetToSquareMetersConverter : IAreaUnitConverter
{
    public AreaTypeUnit InputUnit => AreaTypeUnit.SquareFoot;

    public AreaTypeUnit OutputUnit => AreaTypeUnit.SquareMeter;

    public QuantityValue Convert(QuantityValue value) => 0.09290304 * value;
}