using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Messages;

namespace Infrastructure.EntityConfigurations.MessageConfigurations
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(p => p.Id);

            ToTable("Message");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("MessageId");

            Property(p => p.Token)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("MessageToken");

            Property(p => p.Language)
                .IsRequired()
                .HasColumnName("MessageLanguage");

            Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("MessageContent");
        }
    }
}
