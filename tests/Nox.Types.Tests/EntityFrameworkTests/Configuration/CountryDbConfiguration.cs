using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Nox.Types.Tests.EntityFrameworkTests;

class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255).HasConversion(v => v.Value, v => Text.From(v));
        builder.Property(e => e.Population).HasConversion(v => v.Value, v => Number.From(v));
        builder.OwnsOne(e => e.LatLong);
    }
}