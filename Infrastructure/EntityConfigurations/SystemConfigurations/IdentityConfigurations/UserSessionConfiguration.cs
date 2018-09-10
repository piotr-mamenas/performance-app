using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.IdentityConfigurations
{
    public class UserSessionConfiguration : BaseEntityConfiguration<UserSession>
    {
        public UserSessionConfiguration()
        {
            ToTable("UserSessions");

            Property(w => w.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("UserSessionId");

            Property(w => w.SessionStart)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .HasColumnName("SessionStartTimestamp")
                .IsRequired();

            Property(w => w.SessionEnd)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .HasColumnName("SessionEndTimestamp")
                .IsOptional();

            Property(us => us.AuthenticationToken).IsRequired();

            HasRequired(us => us.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(us => us.UserId);
        }
    }
}
