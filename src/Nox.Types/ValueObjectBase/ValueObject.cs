using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;


namespace Nox.Types;

[Serializable]
public abstract class ValueObject<T, TValueObject> : INoxType 
    where TValueObject : ValueObject<T, TValueObject>, new() 
{
    [NotMapped]
    public T Value { get; protected set; } = default!;

    protected ValueObject() {}

    public static TValueObject From(T value)
    {
        var newObject = new TValueObject
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public virtual ValidationResult Validate()
    {
        return new ValidationResult() {};
    }

    protected static bool EqualOperator(ValueObject<T,TValueObject>? left, ValueObject<T,TValueObject>? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return left is null || left.Equals(right!);
    }

    protected static bool NotEqualOperator(ValueObject<T,TValueObject> left, ValueObject<T, TValueObject> right)
    {
        return !(EqualOperator(left, right));
    }

    public static bool operator ==(ValueObject<T, TValueObject>? a, ValueObject<T, TValueObject>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T, TValueObject>? a, ValueObject<T, TValueObject>? b)
    {
        return !(a == b);
    }

    protected virtual IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), Value!);
    }


    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<T, TValueObject>)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.Value != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject<T, TValueObject>? GetCopy()
    {
        return this.MemberwiseClone() as ValueObject<T, TValueObject>;
    }

    public override string ToString()
    {
        return string.Join(",",this.GetEqualityComponents().Select(o => o.Value?.ToString() ?? string.Empty).ToArray());
    }

    public virtual Type GetUnderlyingType() => typeof(T);

}