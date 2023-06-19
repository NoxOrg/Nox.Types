
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.Types;

namespace Nox.Types.Tests.EntityFrameworkTests;

public class NoxTypesEntityFrameworkTests : TestWithSqlite
{
    [Fact]
    public async Task DatabaseIsAvailableAndCanBeConnectedTo()
    {
        Assert.True(await DbContext.Database.CanConnectAsync());
    }

    [Fact]
    public void TableShouldGetCreated()
    {
        Assert.False(DbContext.Countries.Any());
    }

    [Fact]
    public void AddedItemShouldGetGeneratedId()
    {
        var newItem = new Country() { 
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(46.802496, 8.234392),
            Population = Number.From(8_703_654),
            CountryCode2 = CountryCode2.From("CH"),
            Area = Area.From(41_290_000),
            Culture = Culture.From("de-CH", "German (Switzerland)")
        };
        DbContext.Countries.Add(newItem);
        DbContext.SaveChanges();

        Assert.Equal(CountryId.From(1), newItem.Id);

        var item = DbContext.Countries.First();

        Assert.Equal(1, item.Id.Value);
        Assert.Equal("Switzerland", item.Name.Value);
        Assert.Equal(46.802496, item.LatLong.Latitude);
        Assert.Equal(8.234392, item.LatLong.Longitude);
        Assert.Equal(8_703_654, item.Population?.Value);
        Assert.Equal("CH", item.CountryCode2?.Value);
        Assert.Equal(41_290_000, item.Area.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, item.Area.Unit);
        Assert.Equal("de-CH", item.Culture.Code);
        Assert.Equal("German (Switzerland)", item.Culture.DisplayName);
    }


}
