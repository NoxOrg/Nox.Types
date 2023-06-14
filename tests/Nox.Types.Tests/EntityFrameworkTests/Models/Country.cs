
namespace Nox.Types.Tests.EntityFrameworkTests;

public class CountryId : ValueObject<int, CountryId> { }

public class Country
{
    public CountryId Id { get; set; } = null!;
    public Text Name { get; set; } = null!;
    public Number? Population { get; set; } = null!;
    public LatLong LatLong { get; set; } = null!;
}
