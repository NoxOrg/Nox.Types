using static System.Net.Mime.MediaTypeNames;

namespace Nox.Types.Tests;

public class NoxTextTests
{
    [Fact]
    public void Nox_Text_Constructor_ReturnsSameValue()

    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = new Text(testString);

        Assert.Equal(testString, text.Value);

    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingNonUnicode_WithNonUnicodeCharacterInput_ReturnsSameValue()

    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = new Text(testString, isUnicode: false);

        Assert.Equal(testString, text.Value);

    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingNonUnicode_WithUnicodeCharacterInput_ThrowsException()

    {
        var testString = "二兎を追う者は一兎をも得ず。"; // English translation: “Those who chase two hares won’t even catch one.”

        Assert.Throws<ArgumentException>(() => _ =
            new Text(testString, isUnicode: false)
        );

    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsException()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        Assert.Throws<ArgumentException>(() => _ =
            new Text(testString, maxLength: 3)
        );
    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingMinLength_WithShorterLengthInput_ThrowsException()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        Assert.Throws<ArgumentException>(() => _ =
            new Text(testString, minLength: 100)
        );
    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingUppercase_WithNormalCaseInput_ReturnsUpperInvariantCase()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = new Text(testString, casing: TextTypeCasing.Upper);

        Assert.Equal(testString.ToUpperInvariant(), text.Value);

    }

    [Fact]
    public void Nox_Text_Constructor_SpecifyingLowercase_WithNormalCaseInput_ReturnsLowerInvariantCase()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = new Text(testString, casing: TextTypeCasing.Lower);

        Assert.Equal(testString.ToLowerInvariant(), text.Value);
    }

    [Fact]
    public void Nox_Text_Equality_Tests()
    {
        var testString1 = "It's a test designed to provoke an emotional response - Holden";

        var text1 = new Text(testString1);

        var testString2 = "It's a test designed to provoke an emotional response - Holden";

        var text2 = new Text(testString2);

        Assert.Equal(text1,text2);

        Assert.True(text1.Equals(text2));

        Assert.True(text2.Equals(text1));

        Assert.True(text1 == text2);

        Assert.False(text1 != text2);
    }

    [Fact]
    public void Nox_Text_NonEquality_Tests()
    {
        var testString1 = "It's a test designed to provoke an emotional response - Holden";

        var text1 = new Text(testString1);

        var testString2 = "二兎を追う者は一兎をも得ず。"; // English translation: “Those who chase two hares won’t even catch one.”

        var text2 = new Text(testString2);

        Assert.NotEqual(text1, text2);

        Assert.False(text1.Equals(text2));

        Assert.False(text2.Equals(text1));

        Assert.False(text1 == text2);

        Assert.True(text1 != text2);
    }

    [Fact]
    public void Nox_Text_ToString_Returns_Value()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = new Text(testString);

        var testString2 = text.ToString();

        Assert.Equal(testString, testString2);

    }

    [Fact]
    public void Nox_Text_GetCopy_ReturnsCopy()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text1 = new Text(testString);

        var text2 = text1.GetCopy();

        Assert.NotNull(text2);

        // they look equal
        Assert.Equal(text1, text2);
        Assert.True(text1 == text2);

        // ..and this obviously true
        Assert.True(Object.ReferenceEquals(text1, text1));

        // .. and this is obviously true too
        Assert.True(Object.ReferenceEquals(text2, text2));

        // .. but this is only true if the text1 was cloned/copied to text2
        Assert.False(Object.ReferenceEquals(text1, text2));

    }
}