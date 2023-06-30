using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class MeasurementConversionFactorTests
{
    [Fact]
    public void MeasurementConversionFactor_GetConversionFactor_FromCubicFootToCubicMeter_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(VolumeUnit.CubicFoot, VolumeUnit.CubicMeter);

        factor.Value.Should().Be(0.0283168466);
    }

    [Fact]
    public void MeasurementConversionFactor_GetConversionFactor_FromCubicMeterToCubicFoot_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot);

        factor.Value.Should().Be(35.3146667);
    }
}
