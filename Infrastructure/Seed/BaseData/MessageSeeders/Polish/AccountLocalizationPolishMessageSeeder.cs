using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.Polish
{
    public class AccountLocalizationPolishMessageSeeder : BaseLocalizationSeeder
    {
        public AccountLocalizationPolishMessageSeeder(IDbSet<Message> messages)
            : base(messages,Language.Pl)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "Nazwa Konta"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "Numer Konta"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "Data Otwarcia"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "Data Zamkniecia"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.UpdateAccount",
                Content = "Edycja Konta"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.CreateAccount",
                Content = "Otwarcie Konta"
            });
        }
    }
}
