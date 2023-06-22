using System;

namespace Nox.Types;

internal interface IDistanceCalculator
{
    double Calculate(LatLong origin, LatLong destination);
}
internal class HaversineDistanceCalculator : IDistanceCalculator
{
    private const double EARTH_RADIUS_IN_KM = 6371.0;

    public double Calculate(LatLong origin, LatLong destination)
    {
        // Convert degrees to radians
        var radOrigin = ToRadianCoords(origin);
        var radDestination = ToRadianCoords(destination);

        // Apply Haversine formula
        var a = Math.Pow(Math.Sin((radDestination.Latitude - radOrigin.Latitude) / 2), 2) +
            Math.Cos(radOrigin.Latitude) * Math.Cos(radDestination.Latitude) * Math.Pow(Math.Sin((radDestination.Longitude - radOrigin.Longitude) / 2), 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return EARTH_RADIUS_IN_KM * c;
    }

    private static (double Latitude, double Longitude) ToRadianCoords(LatLong coord)
        => (ToRadians(coord.Latitude), ToRadians(coord.Longitude));

    private static double ToRadians(double degrees)
        => degrees * Math.PI / 180;

}
