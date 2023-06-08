namespace Nox
{
    public class NoxComplexType : NoxSimpleType
    {
        public ObjectTypeOptions? ObjectTypeOptions { get; internal set; }
        public ArrayTypeOptions? CollectionTypeOptions { get; internal set; }
        public ArrayTypeOptions? ArrayTypeOptions { get; internal set; }

    }
}