using System.Web.Mvc;

namespace Web.Extensions
{
    public static class HtmlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string action, string controller)
        {
            var requestUrl = url.RequestContext.HttpContext.Request.Url;

            return $"{requestUrl.Scheme}://{requestUrl.Authority}{url.Action(action, controller)}";
        }
    }
}