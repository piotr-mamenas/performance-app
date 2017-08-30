using System.Configuration;
using System.Web.Mvc;

namespace Web.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName,
            object routeValues = null)
        {
            var scheme = url.RequestContext.HttpContext.Request.Url.Scheme;

            return url.Action(actionName, controllerName, routeValues, scheme);
        }
    }
}