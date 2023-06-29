namespace Nox.Types;

public class HashedTextTypeOptions
{
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;
    public string Salt { get; set; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
}

