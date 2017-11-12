using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.English
{
    public class PartnerLocalizationEnglishMessageSeeder : BaseLocalizationSeeder
    {
        public PartnerLocalizationEnglishMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.En)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Partner.Label.NewPartner",
                Content = "New Partner"
            });
        }
    }
}
