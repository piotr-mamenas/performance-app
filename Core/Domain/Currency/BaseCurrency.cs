namespace Core.Domain.Currency
{
    public class BaseCurrency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }
    }
}
