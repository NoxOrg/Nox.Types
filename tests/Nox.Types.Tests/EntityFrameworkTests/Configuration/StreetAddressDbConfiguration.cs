using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Nox.Types.Tests.EntityFrameworkTests;

internal class StreetAddressDbConfiguration : IEntityTypeConfiguration<StreetAddress>
{
    public void Configure(EntityTypeBuilder<StreetAddress> builder)
    {
        builder.HasKey(e => e.Id);

        // Configure Single-value ValueObjects
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => StreetAddressId.From(v));
        builder.Property(e => e.ZipCode).IsRequired().HasMaxLength(10);
        builder.Property(e => e.City).IsRequired().HasMaxLength(100);

        // Configure Multi-value ValueObjects
        builder.HasOne(e => e.CountryCode2).WithMany();
    }
}