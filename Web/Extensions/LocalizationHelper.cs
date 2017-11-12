using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Domain.Identity;
using Core.Enums;
using Infrastructure.Services;
using Microsoft.AspNet.Identity.Owin;

namespace Web.Extensions
{
    public static class LocalizationHelper
    {
        public static string GetLocalizedString(this HtmlHelper url, string token)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<User>();
            var language = Language.Pl;

            return LocalizationService.GetTextConstantByTokenAsync(token, language);
        }
    }
}