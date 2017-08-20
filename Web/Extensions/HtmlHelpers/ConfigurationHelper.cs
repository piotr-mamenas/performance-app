using System.Configuration;
using System.Web.Mvc;

namespace Web.Extensions.HtmlHelpers
{
    public static class ConfigurationHelper
    {
        public static string GetWebServerUri(this HtmlHelper helper)
        {
            return ConfigurationManager.AppSettings.Get("webServerUri");
        }
    }
}