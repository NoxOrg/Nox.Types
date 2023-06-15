namespace Nox.Types;

public enum AreaTypeUnit
{
    SquareFoot,
    SquareMeter,
}

public static class AreaTypeUnitExtensions
{
    public static string ToSymbol(this AreaTypeUnit unit)
    {
        return unit switch
        {
            AreaTypeUnit.SquareFoot => "ft²",
            _ => "m²",
        };
    }
}