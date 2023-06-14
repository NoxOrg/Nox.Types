using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;
public class TextConverter : ValueConverter<Text,string>
{
    public TextConverter() : base (text => text.Value, str => Text.From(str)) { }
}