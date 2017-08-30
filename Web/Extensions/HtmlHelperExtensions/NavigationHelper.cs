using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Microsoft.Owin.Security.Provider;

namespace Web.Extensions.HtmlHelperExtensions
{
    public static class NavigationHelper
    {
        public static IHtmlString GenerateRibbon(this HtmlHelper helper)
        {
            return helper.Raw(GetNavbar());
        }

        private static string GetNavbar()
        {
            var sitemap = XDocument.Load(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
            var navbarStringBuilder = new StringBuilder();

            if (sitemap.Root != null)
            {
                navbarStringBuilder.AppendLine(GetNavigationItem(sitemap.Root));
            }

            foreach (var navbarLinkNode in sitemap.Elements("SiteMapNode/SiteMapNode"))
            {
                navbarStringBuilder.AppendLine(GetNavigationItem(navbarLinkNode));
            }

            return navbarStringBuilder.ToString();
        }

        public static string GetNavigationItem(XElement node)
        {
            var title = node.Attribute("title")?.Value;
            var action = node.Attribute("action")?.Value;
            var controller = node.Attribute("controller")?.Value;
            var cssClass = node.Attribute("cssClass")?.Value;

            var url = new UrlHelper().AbsoluteAction(action,controller);

            return "<li><a href=\"" + url + "\" class=\"" + cssClass + "\">" + title + "</a></li>";
        }
    }
}