using System;
using System.Collections.Generic;
using System.Text;

namespace Nox.Types;

public sealed class JwtToken : ValueObject<string, JwtToken>
{
    private const char JWTPartsDelimiter = '.';
    private const int NumberOfJwtParts = 3;

    private const int JWTHeaderPart = 0;
    private const int JWTPayloadPart = 1;
    private const int JWTSignaturePart = 2;

    /// <summary>
    /// Validates a <see cref="JwtToken"/> object.
    /// </summary>
    /// <returns>true if the <see cref="JwtToken"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if(string.IsNullOrEmpty(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), "Could not create a Nox JWT Token type as the value cannot be null or empty string."));
        }

        else if(DoesNotHaveValidJWTFormat(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox JWT Token type as value {Value} does not have a valid JWT format."));
        }

        return result;
    }

    private bool DoesNotHaveValidJWTFormat(string value)
    {
        var jwtParts = value.Split(JWTPartsDelimiter);

        if (jwtParts.Length != NumberOfJwtParts)
            return true;

        var header = jwtParts[JWTHeaderPart];
        var payload = jwtParts[JWTPayloadPart];
        var signature = jwtParts[JWTSignaturePart];

        return false;
    }
}
