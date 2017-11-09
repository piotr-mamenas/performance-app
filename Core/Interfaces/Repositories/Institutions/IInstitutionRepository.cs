namespace Core.Interfaces.Repositories.Institution
{
    public interface IInstitutionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
