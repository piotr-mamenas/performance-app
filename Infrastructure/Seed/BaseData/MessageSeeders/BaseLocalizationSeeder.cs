using System.Data.Entity;
using Core.Domain.Messages;
using Core.Enums;

namespace Infrastructure.Seed.BaseData.MessageSeeders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseLocalizationSeeder : BaseSeeder<Message>, IBaseData
    {
        private Language CurrentLanguage { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="currentLanguage"></param>
        protected BaseLocalizationSeeder(IDbSet<Message> messages, Language currentLanguage)
            : base(messages)
        {
            CurrentLanguage = currentLanguage;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AssignLanguage()
        {
            foreach (var seededEntity in SeededEntities)
            {
                seededEntity.Language = CurrentLanguage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Seed()
        {
            AssignLanguage();

            base.Seed();
        }
    }
}
