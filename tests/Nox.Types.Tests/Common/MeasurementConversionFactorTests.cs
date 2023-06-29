using Nox.Common;

namespace Nox.Types.Tests.Common;

public class MeasurementConversionFactorTests
{
    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromFootToMeter_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.Foot, MeasurementTypeUnit.Meter);

        Assert.Equal(0.30480000033, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromMeterToFoot_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.Meter, MeasurementTypeUnit.Foot);

        Assert.Equal(3.28083989142, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromKilometerToMile_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.Kilometer, MeasurementTypeUnit.Mile);

        Assert.Equal(0.62137119102, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromMileToKilometer_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.Mile, MeasurementTypeUnit.Kilometer);

        Assert.Equal(1.60934400315, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.SquareFoot, MeasurementTypeUnit.SquareMeter);

        Assert.Equal(0.09290304, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.SquareMeter, MeasurementTypeUnit.SquareFoot);

        Assert.Equal(10.76391042, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_WithSameSourceAndTargetUnit_ReturnsValue()
    {
        var factor = new MeasurementConversionFactor(MeasurementTypeUnit.Foot, MeasurementTypeUnit.Foot);

        Assert.Equal(1, factor.Value);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_WithUnsupportedConversion_ThrowsException()
    {
        var exception = Assert.Throws<NotImplementedException>(() => _ =
            new MeasurementConversionFactor(MeasurementTypeUnit.SquareMeter, MeasurementTypeUnit.Meter)
        );

        Assert.Equal("No conversion defined from SquareMeter to Meter.", exception.Message);
    }
}
