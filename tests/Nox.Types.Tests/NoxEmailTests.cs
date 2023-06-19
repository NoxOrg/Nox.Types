using FluentValidation;

namespace Nox.Types.Tests;

public class NoxEmailTests
{
    [Fact]
    public void Nox_Email_Constructor_ReturnsSameValue()
    {
        var testEmail = "douglas.adams@domain.com";

        var email = Email.From(testEmail);

        Assert.Equal(testEmail, email.Value);
    }

    [Fact]
    public void Nox_Email_Constructor_WithInvalidInput_ThrowsValidationException()
    {
        var testEmail = "It's a test designed to provoke an emotional response - Holden";

        Assert.Throws<TypeValidationException>(() => _ =
            Email.From(testEmail)
        );
    }

    [Fact]
    public void Nox_Email_User_ReturnsUserPart()
    {
        var testEmail = "douglas.adams@domain.com";

        var email = Email.From(testEmail);

        var user = email.GetUser();

        Assert.Equal("douglas.adams", user);
    }

    [Fact]
    public void Nox_Email_Domain_ReturnsDomainPart()
    {
        var testEmail = "douglas.adams@domain.com";

        var email = Email.From(testEmail);

        var domain = email.GetDomain();

        Assert.Equal("domain.com", domain);
    }

    [Fact]
    public void Nox_Email_Equality_Tests()
    {
        var testEmail1 = "douglas.adams@domain.com";
        var testEmail2 = "Douglas.Adams@domain.com";
        var testEmail3 = "DOUGLAS.ADAMS@DOMAIN.COM";

        var email1 = Email.From(testEmail1);
        var email2 = Email.From(testEmail2);
        var email3 = Email.From(testEmail3);

        Assert.Equal(email1, email2);
        Assert.Equal(email2, email3);
        Assert.Equal(email1, email3);
    }

    [Fact]
    public void Nox_Email_Constructor_FromFullNameEmail_ReturnsEmailAndNameParts()
    {
        var testEmail = "Doug Adams <douglas.adams@domain.com>";

        var email = Email.From(testEmail);

        Assert.Equal("douglas.adams@domain.com", email.Value);
        Assert.Equal("Doug Adams", email.GetName());
    }

}