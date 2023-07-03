using System;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="HashedText"/> type and value object.
/// </summary>
public sealed class HashedText : ValueObject<(string HashText, string Salt), HashedText>
{
    public string HashText => Value.HashText;
    public string Salt => Value.Salt;
    private const string delimiter = "||";

    /// <summary>
    /// Creates HashedText object from already hashed value
    /// </summary>
    /// <param name="hashedValue"></param>
    /// <returns>HashedText object</returns>
    /// <exception cref="TypeValidationException"></exception>
    public static HashedText FromHashedValue(string hashedValue)
    {
        string salt = string.Empty;

        int delimiterLocation = hashedValue.IndexOf(delimiter, StringComparison.Ordinal);
        if (delimiterLocation > 0)
        {
            salt = hashedValue.Substring(delimiterLocation + 1);
            hashedValue = hashedValue.Substring(0, delimiterLocation);
        }

        var newObject = new HashedText
        {
            Value = (hashedValue, salt),
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

        var newObject = GetHashText(value, options);

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public static HashedText From(string value)
        => From(value, new HashedTextTypeOptions());

    public override string ToString() => $"{Value.HashText}{delimiter}{Value.Salt}";

    private static HashedText GetHashText(string plainText, HashedTextTypeOptions hashedTextTypeOptions)
    {
        string hashedText = string.Empty;
        string salt = string.Empty;

        using (var hasher = CreateHasher(hashedTextTypeOptions.HashingAlgorithm))
        {
            byte[] saltBytes = GetSalt(hashedTextTypeOptions.Salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes($"{plainText}");
            AppendBytes(ref plainTextBytes, saltBytes);
            byte[] hashBytes = hasher.ComputeHash(plainTextBytes);

            hashedText = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }

        return new HashedText { Value = (hashedText, salt) };
    }


    private static HashAlgorithm CreateHasher(HashingAlgorithm hashAlgorithm)
    {
        HashAlgorithm hasher = HashAlgorithm.Create(hashAlgorithm.ToString());

        return hasher ?? throw new CryptographicException("Invalid hash algorithm");
    }

    private static byte[] GetSalt(int byteCount)
    {
        byte[] salt = new byte[byteCount];
        RNGCryptoServiceProvider rng = new();
        rng.GetBytes(salt);

        return salt;
    }

    public static void AppendBytes(ref byte[] target, byte[] source)
    {
        int targetLength = target.Length;
        int sourceLength = source.Length;
        if (sourceLength != 0)
        {
            Array.Resize(ref target, targetLength + sourceLength);
            Array.Copy(source, 0, target, targetLength, sourceLength);
        }
    }
}
