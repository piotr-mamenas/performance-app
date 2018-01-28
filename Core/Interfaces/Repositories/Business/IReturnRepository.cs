using Core.Domain.Returns;

namespace Core.Interfaces.Repositories.Business
{
    public interface IReturnRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Return
    {
    }
}