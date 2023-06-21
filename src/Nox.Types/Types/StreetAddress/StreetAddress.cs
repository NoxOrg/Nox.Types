namespace Nox.Types;

    /// <summary>
    /// Represents a Nox <see cref="StreetAddress"/> type and value object.
    /// </summary>
    public sealed class StreetAddress : ValueObject<(string Line1,string Line2, string Line3,string ZipCode,string City, CountryCode2 CountryCode2), StreetAddress>
    {

    }
