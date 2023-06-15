using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace Nox.Types.EntityFramework;


public class NumberConverter : ValueConverter<Number, decimal>
{
    public NumberConverter() : base(number => (decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToDecimalConverter : ValueConverter<Number, decimal> 
{
    public NumberToDecimalConverter() : base(number => (decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToByteConverter : ValueConverter<Number, byte>
{
    public NumberToByteConverter() : base(number => (byte)(decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToShortConverter : ValueConverter<Number, short>
{
    public NumberToShortConverter() : base(number => (short)(decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToInt32Converter : ValueConverter<Number, int>
{
    public NumberToInt32Converter() : base(number => (int)(decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToInt64Converter : ValueConverter<Number, long>
{
    public NumberToInt64Converter() : base(number => (long)(decimal)number.Value, n => Number.From(n)) { }
}

public class NumberToDoubleConverter : ValueConverter<Number, double>
{
    public NumberToDoubleConverter() : base(number => (double)number.Value, n => Number.From(n)) { }
}