using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter() : base(email => email.Value, emailValue => Email.From(emailValue)) { }
}