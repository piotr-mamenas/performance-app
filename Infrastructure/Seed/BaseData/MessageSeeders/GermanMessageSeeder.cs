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
        }
    }
}
