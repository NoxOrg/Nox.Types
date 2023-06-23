# Nox.Types

a Domain driven type system for Nox solutions

## ToString Conventions

Nox does not follow the usual convention for ToString().

The ToString() should return the same result independently of the current culture, for example for DateTime, Currency, dependent types.

The reasoning behind this is to ensure a fully predictable result that facilitates ETL process's and interopability with other systems.

The same is expected for the ToString(string format) overload.

If you need a culture dependent representation create an overload with a IFormatProvider parameter, example

```c#
ToString(IFormatProvider formatProvider);
```

LatLong Nox type example:

```c#
 public override string ToString()
{
    return $"{Value.Latitude.ToString("0.000000", CultureInfo.InvariantCulture)} {Value.Longitude.ToString("0.000000", CultureInfo.InvariantCulture)}";
}

public string ToString(IFormatProvider formatProvider)
{
    return $"{Value.Latitude.ToString(formatProvider)} {Value.Longitude.ToString(formatProvider)}";
}
```
