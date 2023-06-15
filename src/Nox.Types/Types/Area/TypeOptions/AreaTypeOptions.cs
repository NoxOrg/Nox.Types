namespace Nox.Types;

public struct AreaTypeOptions
{
    public static readonly string SquareFootAreaUnit = "SquareFoot";
    public static readonly string SquareMeterAreaUnit = "SquareMeeter";
    public static readonly string[] SupportedAreaUnits = { SquareFootAreaUnit, SquareMeterAreaUnit };

    public AreaTypeOptions() { }
}