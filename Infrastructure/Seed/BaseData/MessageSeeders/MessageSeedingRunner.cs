using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Core.Domain.Messages;
using Infrastructure.Seed.BaseData.MessageSeeders.English;
using Infrastructure.Seed.BaseData.MessageSeeders.German;
using Infrastructure.Seed.BaseData.MessageSeeders.Polish;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    public class MessageSeedingRunner
    {
        private static readonly IList<BaseLocalizationSeeder> Localization = new List<BaseLocalizationSeeder>();

        public static void Run(IDbSet<Message> messages)
        {
            ApplyEnglishLocalization(messages);
            ApplyGermanLocalization(messages);
            ApplyPolishLocalization(messages);

            foreach (var local in Localization)
            {
                local.Seed();
            }
        }

        private static void ApplyEnglishLocalization(IDbSet<Message> messages)
        {
            Localization.Add(new AccountLocalizationEnglishMessageSeeder(messages));
            Localization.Add(new PartnerLocalizationEnglishMessageSeeder(messages));
            Localization.Add(new GlobalLocalizationEnglishMessageSeeder(messages));
        }

        private static void ApplyGermanLocalization(IDbSet<Message> messages)
        {
            Localization.Add(new AccountLocalizationGermanMessageSeeder(messages));
            Localization.Add(new PartnerLocalizationGermanMessageSeeder(messages));
            Localization.Add(new GlobalLocalizationGermanMessageSeeder(messages));
        }

        private static void ApplyPolishLocalization(IDbSet<Message> messages)
        {
            Localization.Add(new AccountLocalizationPolishMessageSeeder(messages));
            Localization.Add(new PartnerLocalizationPolishMessageSeeder(messages));
            Localization.Add(new GlobalLocalizationPolishMessageSeeder(messages));
        }
    }
}
