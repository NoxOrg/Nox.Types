﻿namespace Nox.Types.Tests.EntityFrameworkTests;

public class CountryId : ValueObject<int, CountryId> { }

public sealed class Country
{
    public CountryId Id { get; set; } = null!;
    public Text Name { get; set; } = null!;
    public Number? Population { get; set; } = null!;
    public LatLong LatLong { get; set; } = null!;
    public CountryCode2 CountryCode2 { get; set; } = null!;
    public Area Area { get; set; } = null!;
    
    public Culture Culture { get; set; } = null!;
}
