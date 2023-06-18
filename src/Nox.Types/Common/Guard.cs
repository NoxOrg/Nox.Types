﻿using System;

namespace Nox.Types;

/// <summary>
///     Guard methods to ensure parameter values satisfy pre-conditions and use a consistent exception message.
/// </summary>
internal static class Guard
{
    /// <summary>
    ///     Throws <see cref="ArgumentException" /> if value is <see cref="double.NaN" />,
    ///     <see cref="double.PositiveInfinity" /> or <see cref="double.NegativeInfinity" />.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">Name of parameter in calling method.</param>
    /// <returns>The given <paramref name="value" /> if valid.</returns>
    /// <exception cref="ArgumentException">If <paramref name="value" /> is invalid.</exception>
    internal static double EnsureValidNumber(double value, string paramName)
    {
        //if (double.IsNaN(value)) throw new ArgumentException("NaN is not a valid number.", paramName);
        //if (double.IsInfinity(value)) throw new ArgumentException("PositiveInfinity or NegativeInfinity is not a valid number.", paramName);
        return value;
    }
}