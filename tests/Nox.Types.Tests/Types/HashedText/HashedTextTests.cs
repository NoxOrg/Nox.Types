// ReSharper disable once CheckNamespace
using System.Security.Cryptography;

namespace Nox.Types.Tests.Types;

public class HashedTextTests
{

    [Fact]
    public void Nox_HashedText_Constructor_WithoutOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text);

        Assert.NotNull(hashedText);
        Assert.NotNull(hashedText.Value);
        Assert.NotEqual(text, hashedText.Value);
    }


    [Fact]
    public void Nox_HashedText_Constructor_WithOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        string textHashedExpected = string.Empty;

        using (var sha = SHA256.Create())
        {
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(textData);
            textHashedExpected = Convert.ToBase64String(hash);
        }

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA256});

        Assert.Equal(textHashedExpected, hashedText.Value);
    }

    [Fact]
    public void Nox_HashedText_Equal_CompareHashedValues()
    {
        string text = "Text to hash";
        string textHashedExpected = string.Empty;

        using (var sha = SHA256.Create())
        {
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(textData);
            textHashedExpected = Convert.ToBase64String(hash);
        }

        var hashedText = HashedText.From(text);

        Assert.True(hashedText.Equals(textHashedExpected));
    }

    [Fact]
    public void Nox_HashedText_Equals_ReturnsTrue()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text);

        Assert.True(hashedText.Equals(text));
    }

    [Fact]
    public void Nox_HashedText_Equals_ReturnsFalse()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From($"{text} 1");

        Assert.False(hashedText.Equals(text));
    }
}