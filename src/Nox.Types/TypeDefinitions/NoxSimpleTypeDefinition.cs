using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class NoxSimpleTypeDefinition
    {
        [Required]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;
        
        public string? Description { get; internal set; }

        [Required]
        public NoxType? Type { get; internal set; }

        #region TypeOptions

        public TextTypeOptions? TextTypeOptions { get; set; }
        public NumberTypeOptions? NumberTypeOptions { get; set; }
        public MoneyTypeOptions? MoneyTypeOptions { get; set; }
        public EntityTypeOptions? EntityTypeOptions { get; set; }

        #endregion

        public bool IsRequired { get; internal set; } = false;

        public TypeUserInterface? UserInterface { get; internal set; }

        public bool IsReadonly { get; internal set; } = false;

    }
}