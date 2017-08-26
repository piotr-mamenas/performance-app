namespace Core.Domain.Currencies
{
    public abstract class BaseCurrency<T> : BaseEntity<T> where T : BaseCurrency<T>, new()
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }
    }
}
