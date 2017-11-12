using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.German
{
    public class PartnerLocalizationGermanMessageSeeder : BaseLocalizationSeeder
    {
        public PartnerLocalizationGermanMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.De)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Partner.Label.NewPartner",
                Content = "Neuer Partner"
            });
        }
    }
}
