namespace Core.Domain.Countries
{
    public class BaseCountry<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }
    }
}
