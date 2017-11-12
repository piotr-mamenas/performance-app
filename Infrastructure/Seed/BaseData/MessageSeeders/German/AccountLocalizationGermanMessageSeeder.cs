using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.German
{
    public class AccountLocalizationGermanMessageSeeder : BaseLocalizationSeeder
    {
        public AccountLocalizationGermanMessageSeeder(IDbSet<Message> messages)
            : base(messages, Language.De)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "Kontobezeichnung"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "Kontonummer"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "Eröffnungsdatum"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "Abschlussdatum"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.UpdateAccount",
                Content = "Konto Aktualisierung"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.CreateAccount",
                Content = "Neues Konto"
            });
        }
    }
}
