using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Messages;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.MessageConfigurations
{
    public class MessageConfiguration : BaseEntityConfiguration<Message>
    {
        public MessageConfiguration()
        {
            ToTable("Message");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("MessageId");

            Property(p => p.Token)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("MessageToken");

            Property(p => p.Language)
                .IsRequired()
                .HasColumnName("MessageLanguage");

            Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("MessageContent");

            Map<WarningMessage>(o => o.Requires("MessageType").HasValue((int)MessageType.WarningMessage));
            Map<ErrorMessage>(o => o.Requires("MessageType").HasValue((int)MessageType.ErrorMessage));
            Map<TextConstant>(o => o.Requires("MessageType").HasValue((int)MessageType.TextConstant));
        }
    }
}
