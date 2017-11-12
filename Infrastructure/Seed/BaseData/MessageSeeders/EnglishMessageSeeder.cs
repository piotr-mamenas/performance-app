using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    public class EnglishMessageSeeder : BaseSeeder<Message>, IBaseData
    {
        public EnglishMessageSeeder(IDbSet<Message> messages)
            : base(messages)
        {
            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Partner.Label.NewPartner",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "Account Name",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "Account Number",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "Date Opened",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "Date Closed",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.UpdateAccount",
                Content = "Update Account",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.CreateAccount",
                Content = "New Account",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Edit",
                Content = "Edit",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Delete",
                Content = "Delete",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Save",
                Content = "Save",
                Language = Language.En
            });
        }
    }
}
