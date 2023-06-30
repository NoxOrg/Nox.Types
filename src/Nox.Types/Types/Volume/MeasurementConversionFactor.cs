using System;
using System.Collections.Generic;

namespace Nox.Types;

public class MeasurementConversionFactor
{
    private static readonly Dictionary<(VolumeUnit, VolumeUnit), double> DefinedVolumeConversionFactors = new()
    {
        { (VolumeUnit.CubicFoot,  VolumeUnit.CubicMeter), 0.0283168466 },
        { (VolumeUnit.CubicMeter,  VolumeUnit.CubicFoot), 35.3146667 },
    };

    public double Value { get; }

    public MeasurementConversionFactor(MeasurementUnit sourceUnit, MeasurementUnit targetUnit)
    {
        Value = ResolveConversionFactor(sourceUnit, targetUnit);
    }

    private static double ResolveConversionFactor(MeasurementUnit sourceUnit, MeasurementUnit targetUnit)
    {

        if (sourceUnit is VolumeUnit volumeSourceUnit && targetUnit is VolumeUnit volumeTargetUnit)
        {
            var conversion = (volumeSourceUnit, volumeTargetUnit);

            if (DefinedVolumeConversionFactors.ContainsKey(conversion))
                return DefinedVolumeConversionFactors[conversion];
        }

        if (sourceUnit == targetUnit)
            return 1;

        throw new NotImplementedException($"No conversion defined from {sourceUnit?.Name} to {targetUnit?.Name}.");
    }
}
