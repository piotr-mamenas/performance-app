using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders.English
{
    public class AccountLocalizationEnglishMessageSeeder : BaseLocalizationSeeder
    {
        public AccountLocalizationEnglishMessageSeeder(IDbSet<Message> messages)
            : base(messages,Language.En)
        {
            SeededEntities.Add(new Message
            {
                Token = "Web.Partner.Label.NewPartner",
                Content = "New Partner"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "Account Name"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "Account Number"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "Date Opened"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "Date Closed"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.UpdateAccount",
                Content = "Update Account"
            });

            SeededEntities.Add(new Message
            {
                Token = "Web.Account.Label.CreateAccount",
                Content = "New Account"
            });
        }
    }
}
