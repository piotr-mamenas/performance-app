using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    public class GermanMessageSeeder : BaseSeeder<Message>, IBaseData
    {
        public GermanMessageSeeder(IDbSet<Message> messages)
            : base(messages)
        {
            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Partner.Label.NewPartner",
                Content = "Neuer Partner",
                Language = Language.De
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "Kontobezeichnung",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "Kontonummer",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "Eröffnungsdatum",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "Abschlussdatum",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.UpdateAccount",
                Content = "Konto Aktualisierung",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.CreateAccount",
                Content = "Neues Konto",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Edit",
                Content = "Bearbeiten",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Delete",
                Content = "Löschen",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Save",
                Content = "Speichert",
                Language = Language.En
            });
        }
    }
}
