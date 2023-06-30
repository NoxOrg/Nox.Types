using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="HashedText"/> type and value object.
/// </summary>
public sealed class HashedText : ValueObject<string, HashedText>
{
    public HashedText() : base() { Value = string.Empty; }

    /// <summary>
    /// Creates HashedText object from already hashed value
    /// </summary>
    /// <param name="hashedValue"></param>
    /// <returns>HashedText object</returns>
    /// <exception cref="TypeValidationException"></exception>
    public static HashedText FromHashedValue(string hashedValue)
    {
        var newObject = new HashedText
        {
            Value = hashedValue,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public static HashedText From(string value, HashedTextTypeOptions options)
    {
        options ??= new HashedTextTypeOptions();

        var newObject = new HashedText
        {
            Value = HashText(value, options)
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
