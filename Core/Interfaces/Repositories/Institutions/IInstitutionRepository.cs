namespace Core.Interfaces.Repositories.Institutions
{
    public interface IInstitutionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
