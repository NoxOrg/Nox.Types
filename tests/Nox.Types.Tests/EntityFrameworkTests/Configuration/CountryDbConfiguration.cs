using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types.EntityFramework;

namespace Nox.Types.Tests.EntityFrameworkTests;

class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);

        // Configure Single-value ValueObjects
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255).HasConversion<TextConverter>();
        builder.Property(e => e.Population).HasConversion<NumberToInt32Converter>();
        builder.Property(e => e.CountryCode2).HasConversion<CountryCode2Converter>();
        builder.Property(e => e.AreaInSqKm).HasConversion<AreaToSquareMeterConverter>();
        builder.Property(e => e.CountryNumber).HasMaxLength(3).HasConversion<CountryNumberConverter>();

        // Configure Multi-value ValueObjects
        builder.OwnsOne(e => e.LatLong).Ignore(p => p.Value);
        builder.OwnsOne(e => e.GrossDomesticProduct).Ignore(p=>p.Value);
    }
}