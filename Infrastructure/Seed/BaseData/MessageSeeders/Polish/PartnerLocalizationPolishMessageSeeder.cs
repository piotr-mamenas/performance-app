using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.Polish
{
    public class PartnerLocalizationPolishMessageSeeder : BaseLocalizationSeeder
    {
        public PartnerLocalizationPolishMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.Pl)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Partner.Label.NewPartner",
                Content = "Nowy Partner"
            });
        }
    }
}
