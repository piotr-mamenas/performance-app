using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
            var urlHelper = new UrlHelper();
            var navbarStringBuilder = new StringBuilder();

            if (sitemap.Root != null)
            {
                var brandLogoLink = sitemap.Root.Element("SiteMapNode");
                var title = brandLogoLink?.Attribute("title")?.Value;
                var action = brandLogoLink?.Attribute("action")?.Value;
                var controller = brandLogoLink?.Attribute("controller")?.Value;
                var cssclass = brandLogoLink?.Attribute("cssClass")?.Value;
                var url = urlHelper.AbsoluteAction(action, controller);

                navbarStringBuilder.AppendLine("<li><a href=\"" + url + "\" class=\"" + cssclass + "\">" + title + "</a></li>");
            }

            foreach (var navbarLink in sitemap.Elements("SiteMapNode/SiteMapNode"))
            {
                var title = navbarLink.Attribute("title")?.Value;
                var action = navbarLink.Attribute("action")?.Value;
                var controller = navbarLink.Attribute("controller")?.Value;
                var cssclass = navbarLink.Attribute("cssClass")?.Value;
                var url = urlHelper.AbsoluteAction(action, controller);

                navbarStringBuilder.AppendLine("<li><a href=\"" + url + "\" class=\"" + cssclass + "\">" + title + "</a></li>");
            }

            return navbarStringBuilder.ToString();
        }
    }
}