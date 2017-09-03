namespace Core.Domain.Assets
{
    public abstract class BaseAsset<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public string Isin { get; set; }
    }
}
