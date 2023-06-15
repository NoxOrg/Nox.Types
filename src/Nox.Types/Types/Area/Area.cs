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
    public AreaTypeUnit Unit { get; private set; }

    public static Area FromSquareMeters(double value)
        => From(value, AreaTypeUnit.SquareMeter);

    public static Area FromSquareFeet(double value)
        => From(value, AreaTypeUnit.SquareFoot);

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
    /// true if the <see cref="Area"/> value is valid according to the default or specified <see cref="AreaTypeOptions"/>.
    /// </returns>
    public override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value <= 0 || double.IsNaN(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} is not allowed."));
        }

        if (double.IsInfinity(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value PositiveInfinity or NegativeInfinity are not allowed."));
        }

        if (!(Enum.TryParse(Unit.ToString(), out AreaTypeUnit unit) && unit != AreaTypeUnit.Unknown))
        {
            result.Errors.Add(new ValidationFailure(nameof(Unit), $"Could not create a Nox Area type as area unit {Unit} is not supported."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), GetSquaredMetersValue());
    }

    private double GetSquaredMetersValue()
    {
        return Unit switch
        {
            AreaTypeUnit.SquareFoot => UnitsNet.Area.FromSquareFeet(Value).As(UnitsNet.Units.AreaUnit.SquareMeter),
            _ => Value,
        };
    }
}