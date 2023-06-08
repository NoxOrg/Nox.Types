using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class NoxComplexTypeDefinition : NoxSimpleTypeDefinition
    {
        public ObjectTypeOptions? ObjectTypeOptions { get; internal set; }
        public ArrayTypeOptions? CollectionTypeOptions { get; internal set; }
        public ArrayTypeOptions? ArrayTypeOptions { get; internal set; }

    }
}