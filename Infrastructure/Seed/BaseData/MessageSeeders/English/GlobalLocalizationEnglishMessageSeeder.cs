using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.English
{
    public class GlobalLocalizationEnglishMessageSeeder : BaseLocalizationSeeder
    {
        public GlobalLocalizationEnglishMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.En)
        {
            SeededEntities.Add(new Message
            {
                Token = "Global.Edit",
                Content = "Edit"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Delete",
                Content = "Delete"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Save",
                Content = "Save"
            });
        }
    }
}
