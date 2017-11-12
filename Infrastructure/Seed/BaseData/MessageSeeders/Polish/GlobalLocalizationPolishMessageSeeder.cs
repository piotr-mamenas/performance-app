using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.Polish
{
    public class GlobalLocalizationPolishMessageSeeder : BaseLocalizationSeeder
    {
        public GlobalLocalizationPolishMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.Pl)
        {
            SeededEntities.Add(new Message
            {
                Token = "Global.Edit",
                Content = "Edycja"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Delete",
                Content = "Usuń"
            });

            SeededEntities.Add(new Message
            {
                Token = "Global.Save",
                Content = "Zapisz"
            });
        }
    }
}
