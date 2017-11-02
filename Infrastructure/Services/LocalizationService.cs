using System;
using Core.Interfaces;

namespace Infrastructure.Services
{
    /// <summary>
    /// Infrastructure service for fetching the localization strings
    /// </summary>
    public static class LocalizationService
    {
        private static IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        static LocalizationService()
        {
            UnitOfWork = new UnitOfWork(ApplicationDbContext.Create());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetTextConstant(Type entity, string token)
        {
            return "Constant";
        }
    }
}
