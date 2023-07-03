using FluentAssertions;
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
    public void Countries_CanRead_LatLong()
    {
        double latitude = 46.802496;
        double longitude = 8.234392;

        var newItem = new Country()
        {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(latitude, longitude),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(717_341_603_000, CurrencyCode.CHF),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            DateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2023, 02, 01)),
            LongestHikingTrailInMeters = Length.From(390_000),
            HashedText = HashedText.From("Test123."),
        };
        DbContext.Countries.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var country = DbContext.Countries.First();

        country.LatLong.Latitude.Should().Be(latitude);
        country.LatLong.Longitude.Should().Be(longitude);
    }

    [Fact]
    public void AddedItemShouldGetGeneratedId()
    {
        var newItem = new Country() {
            Name = Text.From("Switzerland"),
            LatLong = LatLong.From(46.802496, 8.234392),
            Population = Number.From(8_703_654),
            GrossDomesticProduct = Money.From(717_341_603_000, CurrencyCode.CHF),
            CountryCode2 = CountryCode2.From("CH"),
            AreaInSqKm = Area.From(41_290_000),
            CultureCode = CultureCode.From("de-CH"),
            CountryNumber = CountryNumber.From(756),
            MonthOfPeakTourism = Month.From(7),
            DistanceInKm = Distance.From(129.522785),
            DateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2023, 02, 01)),
            InternetDomain = InternetDomain.From("admin.ch"),
            CountryCode3 = CountryCode3.From("CHE"),
            IPAddress = IpAddress.From("102.129.143.255"),
            LongestHikingTrailInMeters = Length.From(390_000),
            HashedText = HashedText.From(("Test123.","salt"))
        };
        DbContext.Countries.Add(newItem);
        DbContext.SaveChanges();

        //Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        Assert.Equal(CountryId.From(1), newItem.Id);

        var item = DbContext.Countries.First();

        Assert.Equal(1, item.Id.Value);
        Assert.Equal("Switzerland", item.Name.Value);
        Assert.Equal(46.802496, item.LatLong.Latitude);
        Assert.Equal(8.234392, item.LatLong.Longitude);
        Assert.Equal(8_703_654, item.Population?.Value);
        Assert.Equal("CHF", item.GrossDomesticProduct.CurrencyCode);
        Assert.Equal(CurrencyCode.CHF, item.GrossDomesticProduct.Value.CurrencyCode);
        Assert.Equal(717_341_603_000, item.GrossDomesticProduct.Amount);
        Assert.Equal("CH", item.CountryCode2?.Value);
        Assert.Equal(41_290_000, item.AreaInSqKm.Value);
        Assert.Equal(AreaTypeUnit.SquareMeter, item.AreaInSqKm.Unit);
        Assert.Equal("de-CH", item.CultureCode.Value);
        Assert.Equal(756, item.CountryNumber.Value);
        Assert.Equal(7, item.MonthOfPeakTourism.Value);
        Assert.Equal(129.522785, item.DistanceInKm.Value);
        Assert.Equal(DistanceTypeUnit.Kilometer, item.DistanceInKm.Unit);
        Assert.Equal("admin.ch", item.InternetDomain.Value);
        Assert.Equal("CHE", item.CountryCode3.Value);
        Assert.Equal("102.129.143.255", item.IPAddress.Value);
        Assert.Equal(new DateTime(2023, 01, 01), item.DateTimeRange.Start);
        Assert.Equal(new DateTime(2023, 02, 01), item.DateTimeRange.End);
        Assert.Equal(390_000, item.LongestHikingTrailInMeters.Value);
        Assert.Equal(LengthTypeUnit.Meter, item.LongestHikingTrailInMeters.Unit);
        Assert.Equal(newItem.HashedText.HashText, item.HashedText.HashText);
        Assert.Equal(newItem.HashedText.Salt, item.HashedText.Salt);
    }
}
