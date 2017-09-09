namespace Core.Domain.Prices
{
    public class BasePrice<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
    }
}
