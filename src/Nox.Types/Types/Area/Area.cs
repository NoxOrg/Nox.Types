
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Email"/> type and value object. 
/// </summary>
public class Area : ValueObject<QuantityValue, Area>
{
    private UnitsNet.Area _area;

    new public static Area From(QuantityValue value)
    => From(value, UnitsNet.Units.AreaUnit.SquareMeter);

    public static Area From(QuantityValue value, UnitsNet.Units.AreaUnit unit)
    {
        var requestedArea = UnitsNet.Area.From((decimal)value, unit);

        var newObject = new Area
        {
            _area = requestedArea,
            Value = requestedArea.SquareMeters,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates an <see cref="Area"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Area"/> value is non-negative.</returns>
    public override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type with negative value '{Value}'."));
        }

        return result;
    }

    public QuantityValue ToSquareFeet() => _area.SquareFeet;
    public QuantityValue ToSquareMeters() => _area.SquareMeters;

}
