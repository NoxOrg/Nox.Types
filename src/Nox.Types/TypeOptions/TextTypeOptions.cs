namespace Nox
{
    public class TextTypeOptions
    {
        public bool IsUnicode { get; internal set; } = true;

        public int MinLength { get; internal set; } = 0;

        public int MaxLength { get; internal set; } = 511;

        public TextTypeCasing CharacterCasing { get; internal set; } = TextTypeCasing.Normal;

        public bool IsMultiline { get; internal set; } = false;
    }
}