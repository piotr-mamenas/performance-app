using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Domain.Identity;
using Infrastructure.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Web.Extensions
{
    public static class LocalizationHelper
    {
        public static async Task<string> GetLocalizedString(this HtmlHelper url, string token)
        {
            var language = HttpContext.Current.GetOwinContext().GetUserManager<User>().Language;
            return await LocalizationService.GetTextConstantByTokenAsync(token, language);
        }
    }
}