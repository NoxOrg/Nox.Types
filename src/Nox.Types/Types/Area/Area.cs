using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : ValueObject<QuantityValue, Area>
{
    private const int QUANTITY_VALUE_DECIMAL_PRECISION = 6;
    
    private const long EARTHS_SURFACE_AREA_IN_SQUARE_METERS = 510_072_000_000_000;

    public AreaTypeUnit Unit { get; private set; } = AreaTypeUnit.SquareMeter;

    public Area() { Value = 0; }

    public static Area FromSquareMeters(QuantityValue value)
        => From(value);

    public static Area FromSquareFeet(QuantityValue value)
        => From(value, AreaTypeUnit.SquareFoot);

    new public static Area From(QuantityValue value)
        => From(value, AreaTypeUnit.SquareMeter);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> with the specified <see cref="AreaTypeUnit"/>
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="unit">The <see cref="AreaTypeUnit"/> to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Area From(QuantityValue value, AreaTypeUnit unit)
    {
        var newObject = new Area
        {
            Value = Round(value),
            Unit = unit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as negative area value {Value} is not allowed."));
        }

        if (!Enum.IsDefined(typeof(AreaTypeUnit), Unit))
        {
            result.Errors.Add(new ValidationFailure(nameof(Unit), $"Could not create a Nox Area type as unit {Unit} is not supported."));
        }
        
        if (ToSquareMeters() > EARTHS_SURFACE_AREA_IN_SQUARE_METERS)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} is greater than the surface area of the Earth."));
        }

        return result;
    }

    public override string ToString() => $"{Value:G} {Unit.ToSymbol()}";

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters());
    }

    private QuantityValue? _squareMeters;
    public QuantityValue ToSquareMeters() => (_squareMeters ??= GetAreaIn(AreaTypeUnit.SquareMeter));

    private QuantityValue? _squareFeet;
    public QuantityValue ToSquareFeet() => (_squareFeet ??= GetAreaIn(AreaTypeUnit.SquareFoot));

    private QuantityValue GetAreaIn(AreaTypeUnit unit)
    {
        if (Unit == unit)
            return Round(Value);

        else if (Unit == AreaTypeUnit.SquareMeter && unit == AreaTypeUnit.SquareFoot)
            return Round(Value * 10.76391042);

        else if (Unit == AreaTypeUnit.SquareFoot && unit == AreaTypeUnit.SquareMeter)
            return Round(Value * 0.09290304);

        throw new NotImplementedException($"No conversion defined from {Unit} to {unit}");
    }

    private static QuantityValue Round(QuantityValue value)
        => Math.Round((double)value, QUANTITY_VALUE_DECIMAL_PRECISION);
}