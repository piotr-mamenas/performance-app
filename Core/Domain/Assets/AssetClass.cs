namespace Core.Domain.Assets
{
    public class AssetClass : BaseEntity
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}
