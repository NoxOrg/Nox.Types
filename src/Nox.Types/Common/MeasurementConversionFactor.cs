using System;
using System.Linq;

namespace Nox.Common;

public class MeasurementConversionFactor
{
    private const string Foot = "Foot";
    private const string Meter = "Meter";
    private const string Kilometer = "Kilometer";
    private const string Mile = "Mile";
    private static readonly string[] _lengthUnits = new[] { Foot, Meter, Kilometer, Mile }; 

    private const string SquareFoot = "SquareFoot";
    private const string SquareMeter = "SquareMeter";
    private static readonly string[] _areaUnits = new[] { SquareFoot, SquareMeter }; 

    public double Value { get; }

    public MeasurementConversionFactor(Enum sourceUnit, Enum targetUnit)
        : this(sourceUnit.ToString(), targetUnit.ToString())
    {
    }

    public MeasurementConversionFactor(string sourceUnit, string targetUnit)
    {
        Value = ResolveConversionFactor(sourceUnit, targetUnit)
            ?? throw new NotImplementedException($"No conversion defined from {sourceUnit} to {targetUnit}.");
    }

    private double? ResolveConversionFactor(string sourceUnit, string targetUnit)
    {
        return IsSupported(sourceUnit) && IsSupported(targetUnit)
            ? ResolveConversionFactorForSupportedUnits(sourceUnit, targetUnit)
            : null;
    }

    private bool IsSupported(string unit)
        => _lengthUnits.Contains(unit) || _areaUnits.Contains(unit);
   
    private double? ResolveConversionFactorForSupportedUnits(string sourceUnit, string targetUnit)
    {
        if (sourceUnit == targetUnit)
            return 1;

        else if (sourceUnit == Foot && targetUnit == Meter)
            return 0.30480000033;

        else if (sourceUnit == Meter && targetUnit == Foot)
            return 3.28083989142;

        else if (sourceUnit == Kilometer && targetUnit == Mile)
            return 0.62137119102;

        else if (sourceUnit == Mile && targetUnit == Kilometer)
            return 1.60934400315;

        else if (sourceUnit == SquareFoot && targetUnit == SquareMeter)
            return 0.09290304;

        else if (sourceUnit == SquareMeter && targetUnit == SquareFoot)
            return 10.76391042;

        return null;
    }
}
