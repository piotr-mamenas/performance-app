using System.Data.Entity.ModelConfiguration;
using Core.Domain;

namespace Infrastructure.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            Property(e => e.IsDeleted).HasColumnName("IsDeleted");

            HasKey(e => e.Id);
        }
    }
}
