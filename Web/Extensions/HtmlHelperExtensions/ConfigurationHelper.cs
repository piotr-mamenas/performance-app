using System.Configuration;
using System.Web.Mvc;

namespace Web.Extensions.HtmlHelperExtensions
{
    public static class ConfigurationHelper
    {
        public static string GetWebServerUri(this HtmlHelper helper)
        {
            return ConfigurationManager.AppSettings["webServerUri"];
        }
    }
}