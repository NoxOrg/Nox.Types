﻿
namespace Nox.Types;

public struct TextTypeOptions
{
    public TextTypeOptions() { }
    public uint MinLength { get; set; } = 0;
    public uint MaxLength { get; set; } = 255;
    public bool IsUnicode { get; set; } = true;
    public TextTypeCasing Casing { get; set; } = TextTypeCasing.Normal;
}