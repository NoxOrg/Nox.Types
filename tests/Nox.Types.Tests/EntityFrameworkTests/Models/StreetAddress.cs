namespace Nox.Types.Tests.EntityFrameworkTests;

public class StreetAddressId : ValueObject<int, StreetAddressId>
{ }

public sealed class StreetAddress
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public StreetAddressId Id { get; set; } = null!;

    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country ISO code.
    /// </summary>
    public Country CountryCode2 { get; set; } = null!;
}