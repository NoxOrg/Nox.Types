
namespace Nox.Types.Tests.EntityFrameworkTests;

public class CountryId : ValueObject<int, CountryId> { }

public class Country
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public CountryId Id { get; set; } = null!;
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public Text Name { get; set; } = null!;
    /// <summary>
    /// Gets or sets the population.
    /// </summary>
    public Number? Population { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the latitude and longitude.
    /// </summary>
    public LatLong LatLong { get; set; } = null!;
    /// <summary>
    /// Gets or sets the gross domestic product(GDP).
    /// </summary>
    public Money GrossDomesticProduct { get; set; } = null!;
}
