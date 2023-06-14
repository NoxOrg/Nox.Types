using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Nox.Types.Tests.EntityFrameworkTests;

public abstract class TestWithSqlite : IDisposable
{
    private const string InMemoryConnectionString = "DataSource=:memory:";
    private readonly SqliteConnection _connection;

    protected readonly SampleDbContext DbContext;

    protected TestWithSqlite()
    {
        _connection = new SqliteConnection(InMemoryConnectionString);
        _connection.Open();
        var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseSqlite(_connection)
                .Options;
        DbContext = new SampleDbContext(options);
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _connection.Close();
    }
}