
using System.Collections.Generic;

namespace Nox.Types;

public class HashedTextTypeOptions
{
    public string HashingAlgorithm { get; set; } = "SHA256";

    private static readonly List<string> _supportedHashingAlgorithms = new List<string>() { "SHA", "SHA256", "SHA128", "SHA512" };

    internal static ValidationResult ValidateHashingAlgorithm(string hashingAlgorithm)
    {
        var validationResult = new ValidationResult();

        if(hashingAlgorithm == null || !_supportedHashingAlgorithms.Contains(hashingAlgorithm))
        {
            validationResult.Errors.Add(new ValidationFailure(nameof(hashingAlgorithm), $"Invalid hash algorithm {hashingAlgorithm}"));

        }

        return validationResult;
    }
}

