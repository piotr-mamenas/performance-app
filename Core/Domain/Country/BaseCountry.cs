namespace Core.Domain.Country
{
    public class BaseCountry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }
    }
}
