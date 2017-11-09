using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Partners;

namespace Infrastructure.EntityConfigurations.ContactConfigurations
{
    public class ContactConfiguration : EntityTypeConfiguration<PartnerContact>
    {
        public ContactConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(c => c.Id);

            ToTable("Contact");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ContactId");

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("ContactName");

            Property(c => c.FirstName)
                .HasMaxLength(255)
                .HasColumnName("ContactFirstName");

            Property(c => c.LastName)
                .HasMaxLength(255)
                .HasColumnName("ContactLastName");

            Property(c => c.Email)
                .HasMaxLength(255)
                .HasColumnName("ContactEmail");

            Property(c => c.PhoneNumber)
                .HasMaxLength(40)
                .HasColumnName("ContactPhoneNumber");

            HasRequired(c => c.Partner)
                .WithMany(p => p.Contacts)
                .WillCascadeOnDelete(false);
        }
    }
}
