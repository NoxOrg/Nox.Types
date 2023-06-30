using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;


public class HashedTextConverter : ValueConverter<HashedText, string>
{
    public HashedTextConverter() : base(hashedText => hashedText.Value, hashedTextValue => HashedText.FromHashedValue(hashedTextValue)) { }
}

