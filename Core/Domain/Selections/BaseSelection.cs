namespace Core.Domain.Selections
{
    public class BaseSelection<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
    }
}
