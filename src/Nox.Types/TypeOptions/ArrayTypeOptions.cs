using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class ArrayTypeOptions: NoxSimpleTypeDefinition 
    {
        public ObjectTypeOptions? ObjectTypeOptions { get; internal set; }
    }
}