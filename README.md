# Welcome

:no_entry: [DEPRECATED] Active at https://github.com/NoxOrg/Nox.Generator

deprecated / obsolete

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

## Versioning

We are using [SemVer](https://semver.org/) for versioning our deliverables.

To manage this version we are using [GitVersion](https://github.com/GitTools/GitVersion) tool.

### Using it locally

You can use gitversion locally to test and setup configuration. To do that intall the dotnet tool `dotnet tool install --global GitVersion.Tool --version 5.*`

run `dotnet-gitversion` to see the current variables of git version

run `dotnet-gitversion /updateprojectfiles` to update csproject files

## Release

Just Create a release in GitHub, tag it properly, and that is all. In the future we want to automate this process.
