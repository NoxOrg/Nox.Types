using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public abstract class ValueObject<T>
{

    protected T _value;
    
    public T Value => _value;

    protected ValueObject(T value)
    {
        _value = value;
    }

    protected static bool EqualOperator(ValueObject<T>? left, ValueObject<T>? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return left is null || left.Equals(right!);
    }

    protected static bool NotEqualOperator(ValueObject<T> left, ValueObject<T> right)
    {
        return !(EqualOperator(left, right));
    }


    public static bool operator ==(ValueObject<T>? a, ValueObject<T>? b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T>? a, ValueObject<T>? b)
    {
        return !(a == b);
    }

    protected abstract IEnumerable<T> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<T>)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject<T>? GetCopy()
    {
        return this.MemberwiseClone() as ValueObject<T>;
    }

    public override string ToString()
    {
        return string.Join(",",this.GetEqualityComponents().Select(o => o?.ToString() ?? string.Empty).ToArray());
    }
}