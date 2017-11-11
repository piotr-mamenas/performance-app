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
        }
    }
}
