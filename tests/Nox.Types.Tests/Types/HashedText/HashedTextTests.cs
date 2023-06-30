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
        Assert.NotNull(hashedText.Value);
        Assert.NotEqual(text, hashedText.Value);
    }


    [Fact]
    public void HashedText_Constructor_WithOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textData);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = "" });

        Assert.Equal(textHashedExpected, hashedText.Value);
    }

    [Fact]
    public void HashedText_Equals_ReturnsTrue()
    {
        string text = "Text to hash";
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textData);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = "" });
        var expectedHashedText = HashedText.FromHashedValue(textHashedExpected);

        Assert.True(hashedText.Equals(expectedHashedText));
    }

    [Fact]
    public void HashedText_Equals_ReturnsFalse_Salting()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = "salt" });
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
}