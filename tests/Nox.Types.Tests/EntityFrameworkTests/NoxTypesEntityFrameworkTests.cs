
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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
        var newItem = new Country() { Name = Text.From("Switzerland"), Population = Number.From(8_703_654)};
        DbContext.Countries.Add(newItem);
        DbContext.SaveChanges();

        Assert.Equal(CountryId.From(1), newItem.Id);
    }
}
