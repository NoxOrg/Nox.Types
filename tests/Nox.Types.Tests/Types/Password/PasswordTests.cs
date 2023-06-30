// ReSharper disable once CheckNamespace
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Nox.Types.Tests.Types;

public class PasswordTests
{
    [Fact]
    public void Nox_Password_Constructor_WithoutOptions_ReturnsHashedValue()
    {
        string text = "Test123.";
        string textHashedExpected = string.Empty;

        using (var sha = SHA256.Create())
        {
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(textData);
            textHashedExpected = Convert.ToBase64String(hash);
        }

        var password = Password.From(text);
        Assert.True(password.Equals(text));
    }

    [Theory]
    [InlineData("test123.")]
    [InlineData("TEST123.")]
    [InlineData("Test123")]
    [InlineData("test.123.")]
    [InlineData("")]
    [InlineData("test")]
    public void Nox_Password_Constructor_WithInvalidInput_ThrowsValidationException(string testPassword)
    {
        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(testPassword)
        );
    }

    [Theory]
    [InlineData("passWord1.")]
    [InlineData("test.Password1")]
    [InlineData(".Correct2$PassWord")]
    public void Nox_Password_Constructor_WithValidInput_DefaultValues(string testPassword)
    {

        var password = Password.From(testPassword);

        Assert.True(password.Equals(testPassword));
    }

    [Theory]
    [InlineData("passWord1.")]
    [InlineData("test.Password1")]
    [InlineData(".Correct2$PassWord")]
    public void Nox_Password_ForceDigits(string testPassword)
    {
        PasswordTypeOptions options = new() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = true, ForceSymbol = false, ForceUppercase = false };

        var password = Password.From(testPassword, options);

        Assert.True(password.Equals(testPassword));
    }

    [Theory]
    [InlineData("passWord.")]
    [InlineData("test.Password")]
    [InlineData(".Correct$PassWord")]
    public void Nox_Password_ForceDigits_ThrowsValidationException(string testPassword)
    {
        PasswordTypeOptions options = new() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = true, ForceSymbol = false, ForceUppercase = false };

        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(testPassword,options)
        );

    }

    [Theory]
    [InlineData("password1.")]
    [InlineData("test.password1")]
    [InlineData(".correct2$password")]
    public void Nox_Password_ForceUppercase_ThrowsValidationException(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = false, ForceSymbol = false, ForceUppercase = true };

        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(testPassword, options)
        );
    }

    [Theory]
    [InlineData("passWord1.")]
    [InlineData("test.Password1")]
    [InlineData(".Correct2$PassWord")]
    public void Nox_Password_ForceUppercase(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = false, ForceSymbol = false, ForceUppercase = true };

        var password = Password.From(testPassword, options);

        Assert.True(password.Equals(testPassword));
    }

    [Theory]
    [InlineData("passWord1.")]
    [InlineData("test.Password1")]
    [InlineData(".Correct2$PassWord")]
    public void Nox_Password_ForceLowecase(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = true, ForceNumber = false, ForceSymbol = false, ForceUppercase = false };

        var password = Password.From(testPassword, options);

        Assert.True(password.Equals(testPassword));
    }

    [Theory]
    [InlineData("PASSWORD.")]
    [InlineData("TEST.PASSWORD")]
    public void Nox_Password_ForceLowerrcase_ThrowsValidationException(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = true, ForceNumber = false, ForceSymbol = false, ForceUppercase = false };

        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(testPassword, options)
        );
    }

    [Theory]
    [InlineData("passWord1.")]
    [InlineData("test.Password1")]
    [InlineData(".Correct2$PassWord")]
    public void Nox_Password_ForceSymbol(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = false, ForceSymbol = true, ForceUppercase = false };

        var password = Password.From(testPassword, options);

        Assert.True(password.Equals(testPassword));
    }

    [Theory]
    [InlineData("passWord1")]
    [InlineData("testPassword1")]
    [InlineData("Correct2PassWord")]
    public void Nox_Password_ForceSymbol_ThrowsValidationException(string testPassword)
    {
        PasswordTypeOptions options = new PasswordTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, ForceLowercase = false, ForceNumber = false, ForceSymbol = true, ForceUppercase = false };

        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(testPassword, options)
        );
    }
}