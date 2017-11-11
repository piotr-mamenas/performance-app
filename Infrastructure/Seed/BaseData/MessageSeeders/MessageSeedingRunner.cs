using System.Data.Entity;
using System.Runtime.InteropServices;
using Core.Domain.Messages;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    public class MessageSeedingRunner
    {
        public static void Run(IDbSet<Message> messages)
        {
            var englishSeeder = new EnglishMessageSeeder(messages);
            englishSeeder.Seed();

            var germanSeeder = new GermanMessageSeeder(messages)
            {
                Index = englishSeeder.Index++
            };
            germanSeeder.Seed();

            var polishSeeder = new PolishMessageSeeder(messages)
            {
                Index = englishSeeder.Index++
            };
            polishSeeder.Seed();
        }
    }
}
