using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    public class PolishMessageSeeder : BaseSeeder<Message>, IBaseData
    {
        public PolishMessageSeeder(IDbSet<Message> messages)
            : base(messages)
        {
            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Partner.Label.NewPartner",
                Content = "Nowy Partner",
                Language = Language.Pl
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountName",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.AccountNumber",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateOpened",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.AccountList.Label.DateClosed",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.UpdateAccount",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Web.Account.Label.CreateAccount",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Edit",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Delete",
                Content = "New Partner",
                Language = Language.En
            });

            SeededEntities.Add(new Message
            {
                Id = Index++,
                Token = "Global.Save",
                Content = "New Partner",
                Language = Language.En
            });
        }
    }
}
