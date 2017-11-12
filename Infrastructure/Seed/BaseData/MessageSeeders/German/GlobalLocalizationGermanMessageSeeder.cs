using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.German
{
    public class GlobalLocalizationGermanMessageSeeder : BaseLocalizationSeeder
    {
        public GlobalLocalizationGermanMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.De)
        {
            SeededEntities.Add(new Message
            {
                Token = "Global.Edit",
                Content = "Bearbeiten"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Delete",
                Content = "Löschen"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Save",
                Content = "Speichert"
            });
        }
    }
}
