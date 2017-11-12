using System;
using System.Threading.Tasks;
using Core.Domain.Messages;
using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services
{
    /// <summary>
    /// Infrastructure service for fetching the localization strings
    /// </summary>
    public static class LocalizationService
    {
        private static IUnitOfWork UnitOfWork { get; }

        private static IRepository<Message> MessageRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static LocalizationService()
        {
            UnitOfWork = new UnitOfWork(ApplicationDbContext.Create());
            MessageRepository = UnitOfWork.Messages;
        }

        /// <summary>
        /// Method fetches the content of a text constant specified by the token and language provided
        /// This method should be used for any non entity based localizations
        /// </summary>
        /// <param name="token">The token for which to fetch the localization constant</param>
        /// <param name="language">Language for which to fetch the constant</param>
        /// <returns></returns>
        public static string GetTextConstantByTokenAsync(string token, Language language)
        {
            var textConstant = MessageRepository.SingleOrDefaultAsync(m => m.Token == token && m.Language == language).Result;

            if (textConstant == null)
            {
                throw new NullReferenceException("Localization token could not be found");
            }
            return textConstant.Content;
        }
    }
}
