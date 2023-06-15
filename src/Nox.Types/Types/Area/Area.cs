using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : ValueObject<double, Area>
{
    public AreaTypeUnit Unit { get; private set; } = AreaTypeUnit.SquareMeter;

    public Area() { Value = 0; }

    public static Area FromSquareMeters(double value)
        => From(value);

    public static Area FromSquareFeet(double value)
        => From(value, AreaTypeUnit.SquareFoot);

    new public static Area From(double value)
        => From(value, AreaTypeUnit.SquareMeter);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> with the specified <see cref="AreaTypeUnit"/>
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="unit">The <see cref="AreaTypeUnit"/> to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Area From(double value, AreaTypeUnit unit)
    {
        var newObject = new Area
        {
            Value = value,
            Unit = unit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return newObject;
    }


    /// <summary>
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
    /// </returns>
    public override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0 || double.IsNaN(Value) || double.IsInfinity(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} is not allowed."));
        }

        if (!Enum.IsDefined(typeof(AreaTypeUnit), Unit))
        {
            result.Errors.Add(new ValidationFailure(nameof(Unit), $"Could not create a Nox Area type as area unit {Unit} is not supported."));
        }

        return result;
    }

    public override string ToString() => $"{Value} {Unit.ToSymbol()}";

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters());
    }

    private double? _squareMeters;
    public double ToSquareMeters() => (_squareMeters ??= GetAreaIn(AreaTypeUnit.SquareMeter));

    private double? _squareFeet;
    public double ToSquareFeet() => (_squareFeet ??= GetAreaIn(AreaTypeUnit.SquareFoot));

    private double GetAreaIn(AreaTypeUnit unit)
        => UnitsNet.Area.From(Value, ToExternalUnit(Unit)).As(ToExternalUnit(unit));

    private static UnitsNet.Units.AreaUnit ToExternalUnit(AreaTypeUnit unit)
    {
        return unit switch
        {
            AreaTypeUnit.SquareFoot => UnitsNet.Units.AreaUnit.SquareFoot,
            _ => UnitsNet.Units.AreaUnit.SquareMeter,
        };
    }
}