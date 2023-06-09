namespace Nox.Types;

public enum NoxType
{
    // Complex types
    @Array,
    @Collection,
    @Object,
    // This is complex, needs to include CountryCode 
    VatNumber, 

    // Compound Types - requires multiple fields to persist
    [CompoundType] Entity,
    [CompoundType] LatLong,
    [CompoundType] Money,
    [CompoundType] StreetAddress,
    [CompoundType] TranslatedText,
    [CompoundType] DateTimeRange,

    // Simple Types
    Area,
    AutoNumber,
    Boolean,
    Color,
    Colour,
    CountryCode2,
    CountryCode3,
    CountryNumber,
    CultureCode,
    CurrencyCode,
    CurrencyNumber,
    Date,
    Month,
    Year,
    DateTime,
    DateTimeDuration,
    DateTimeSchedule,
    Distance,
    Email,
    EncryptedText,
    File,
    Formula,
    Guid,
    HashedText,
    Html,
    Image,
    ImageJpg,
    ImagePng,
    ImageSvg,
    InternetDomain,
    IpAddress,
    Json,
    JwtToken,
    LanguageCode,
    Length,
    MacAddress,
    Markdown,
    Nuid,
    Number,
    Password,
    Percentage,
    PhoneNumber,
    Temperature,
    Text,
    Time,
    TimeZoneCode,
    Uri,
    Url,
    User,
    Volume,
    Weight,
    Yaml,
}