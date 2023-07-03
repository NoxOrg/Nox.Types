// ReSharper disable once CheckNamespace
using System.Security.Cryptography;

namespace Nox.Types.Tests.Types;

public class HashedTextTests
{

    [Fact]
    public void HashedText_Constructor_WithoutOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text);

        Assert.NotNull(hashedText);
        Assert.NotNull(hashedText.Salt);
        Assert.NotEqual(text, hashedText.HashText);
    }


    [Fact]
    public void HashedText_Constructor_WithOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textData);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });

        Assert.Equal(textHashedExpected, hashedText.HashText);
    }

    [Fact]
    public void HashedText_Equals_ReturnsTrue()
    {
        string text = "Text to hash";
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textBytes);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });
        var expectedHashedText = HashedText.FromHashedValue(textHashedExpected);

        Assert.True(hashedText.Equals(expectedHashedText));
    }

    [Fact]
    public void HashedText_Equals_ReturnsFalse_Salting()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });
        var hashedTextNoSalting = HashedText.From(text);

        Assert.False(hashedText.Equals(hashedTextNoSalting));
    }

    [Fact]
    public void HashedText_Equals_ReturnsFalse()
    {
        string text = "Text to hash";
        string text1 = $"{text} 1";
        var hashedText1 = HashedText.From(text1);
        var hashedText = HashedText.From(text);

        Assert.False(hashedText.Equals(hashedText1));
    }

    [Fact]
    public void HashedText_FromHashedValue_Delimiter()
    {
        string text = "Text to hash";
        string salt = "Salt";
        var hashedText = HashedText.FromHashedValue($"{text}||{salt}");

        Assert.Equal(text, hashedText.HashText);
        Assert.Equal(salt, hashedText.Salt);
    }

    [Fact]
    public void HashedText_FromHashedValue_Delimiter_NoSalt()
    {
        string text = "Text to hash";
        string salt = string.Empty;
        var hashedText = HashedText.FromHashedValue($"{text}||{salt}");

        Assert.Equal(text, hashedText.HashText);
        Assert.Equal(salt, hashedText.Salt);
    }
}