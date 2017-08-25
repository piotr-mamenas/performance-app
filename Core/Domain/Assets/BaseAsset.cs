namespace Core.Domain.Assets
{
    public class BaseAsset<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }
    }
}
