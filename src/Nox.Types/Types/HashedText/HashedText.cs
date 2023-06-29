using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="HashedText"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class HashedText : ValueObject<string, HashedText>
{
    public HashedText() : base() { Value = string.Empty; }

    private HashedTextTypeOptions _hashedTextTypeOptions = new();

    public static HashedText From(string value, HashedTextTypeOptions options)
    {
        if (options == null)
        {
            options = new HashedTextTypeOptions();
        }

        var newObject = new HashedText
        {
            Value = HashText(value, options),
            _hashedTextTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    new public static HashedText From(string value)
        => From(value, new HashedTextTypeOptions());

    public bool Equals(string value)
    {
        if (value == null) throw new ArgumentNullException("value", "Text to hash cannot be null.");

        // check if value is already hashed
        if(value.Equals(Value)) return true;

        string hashedText = HashText(value, _hashedTextTypeOptions);

        return hashedText.Equals(Value);
    }

    private static string HashText(string plainText, HashedTextTypeOptions hashedTextTypeOptions)
    {
        string hashedText = string.Empty;
        using (var hasher = CreateHasher(hashedTextTypeOptions.HashingAlgorithm))
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes($"{plainText}{hashedTextTypeOptions.Salt}");
            byte[] hashBytes = hasher.ComputeHash(plainTextBytes);
            hashedText = Convert.ToBase64String(hashBytes);
        }

        return hashedText;
    }


    static HashAlgorithm CreateHasher(HashingAlgorithm hashAlgorithm)
    {
        HashAlgorithm hasher = HashAlgorithm.Create(hashAlgorithm.ToString());

        return hasher ?? throw new CryptographicException("Invalid hash algorithm");
    }
}
