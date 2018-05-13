namespace Core.Domain.Assets
{
    public class AssetClass : BaseEntity
    {
        public static int Bond = 1;
        public static int Equity = 2;

        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}
