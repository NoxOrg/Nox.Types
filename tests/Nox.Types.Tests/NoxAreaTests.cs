
using FluentValidation;

namespace Nox.Types.Tests;

public class NoxAreaTests
{
    [Fact]
    public void Nox_Area_Constructor_ReturnsSameValue()
    {
        var testArea = 10;

        var area = Area.From(testArea);

        Assert.Equal(testArea, area.Value);
    }

    [Fact]
    public void Nox_Area_Constructor_WithUnits_ReturnsSameValue()
    {
        var testArea = 107.6391;

        var area = Area.From(testArea, UnitsNet.Units.AreaUnit.SquareFoot);

        Assert.Equal(testArea, area.ToSquareFeet());
    }

    [Fact]
    public void Nox_Area_Constructor_WithNegativeValue_ThrowsValidationException()
    {
        var testArea = -10;

        var exception = Assert.Throws<ValidationException>( () => _ =
            Area.From(testArea, UnitsNet.Units.AreaUnit.SquareMeter)
        );

        Assert.Equal("Could not create a Nox Area type with negative value '-10'.", exception.Errors.First().ErrorMessage);

    }

    [Fact]
    public void Nox_Area_ToSquareFeet_ReturnsConvertedValue()
    {
        var testArea = 10;

        var area = Area.From(testArea);

        Assert.Equal(107.63910416709722, area.ToSquareFeet());
    }

    [Fact]
    public void Nox_Area_ToSquareMeter_ReturnsConvertedValue()
    {
        var testArea = 107.6391;

        var area = Area.From(testArea,UnitsNet.Units.AreaUnit.SquareFoot);

        Assert.Equal(10, Math.Round((decimal)area.ToSquareMeters(), 4));
    }
}
