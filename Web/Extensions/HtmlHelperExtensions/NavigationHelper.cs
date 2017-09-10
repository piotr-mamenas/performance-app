using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Web.Extensions.HtmlHelperExtensions
{
    // TODO: The generator is inserting self link as first item on navbar, also gotta fix css for icon display
    public static class NavigationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString GenerateRibbon(this HtmlHelper helper)
        {
            return helper.Raw(GetNavbar());
        }

        private static string GetNavbarHeader(XDocument node)
        {
            var sitemapNode = new SiteMapNode(node.GetHeaderXmlElement());

            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.AbsoluteAction(sitemapNode.Action, sitemapNode.Controller);

            var headerStringBuilder = new StringBuilder();

            headerStringBuilder.AppendLine("<div class=\"navbar-header\">");
            headerStringBuilder.AppendLine("<a href=\"" + url + "\" class=\"navbar-brand\">" + sitemapNode.Display + "</a>");
            headerStringBuilder.AppendLine("</div>");
            return headerStringBuilder.ToString();
            //< div class="navbar-header">
            //   @Html.ActionLink("Emperors Lantern", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            //   </div>
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GetNavbar()
        {
            var sitemap = XDocument.Load(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
            var navbarStringBuilder = new StringBuilder();
            
            navbarStringBuilder.AppendLine("<nav class=\"navbar navbar-default\" role=\"navigation\">");
            navbarStringBuilder.AppendLine(GetNavbarHeader(sitemap));
            navbarStringBuilder.AppendLine("<ul class=\"nav navbar-nav\">");
            foreach (var navbarLinkNode in sitemap.GetNavbarXmlElements())
            {
                navbarStringBuilder.AppendLine(GetNavigationItem(navbarLinkNode));
            }
            
            navbarStringBuilder.AppendLine("</ul>");
            navbarStringBuilder.AppendLine("</nav>");
            navbarStringBuilder.AppendLine(GetSubNavbar(sitemap));

            return navbarStringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string GetNavigationItem(XElement node)
        {
            var siteMapNode = new SiteMapNode(node);

            //var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            //var url = urlHelper.AbsoluteAction(siteMapNode.Action, siteMapNode.Controller);
            //return "<li><a href=\"" + url + "\"><span style=\"margin-right:5px;\" class=\"" + cssClass + "\"></span>" + display + "</a></li>";
            // TODO: Incorporating mobile view navbar that displays without the subnavigation items
            return "<li class=\"dropdown\">" +
                   "<a href=\"#\" data-toggle=\"collapse\" data-target=\"#" + siteMapNode.NavId + "\"><span style=\"margin-right:5px;\" class=\"" + siteMapNode.CssClass +
                   "\"></span>" + siteMapNode.Display + "</a></li>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string GetSubNavbar(XDocument node)
        {
            var subNavbarBuilder = new StringBuilder();

            subNavbarBuilder.AppendLine("<nav class=\"navbar navbar-default\" role=\"navigation\" id=\"subnavbar\">");

            foreach (var navbarItem in node.GetNavbarXmlElements())
            {
                var navId = (string) navbarItem.Attribute("navId");
                subNavbarBuilder.AppendLine(GetSubNavigationItem(navbarItem, navId));
            }

            subNavbarBuilder.AppendLine("</nav>");

            return subNavbarBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="navId"></param>
        /// <returns></returns>
        public static string GetSubNavigationItem(XElement node, string navId)
        {
            var subNavBuilder = new StringBuilder();

            subNavBuilder.AppendLine("<ul class=\"nav navbar-nav collapse\" id=\"" + navId + "\">");

            foreach (var subNav in node.GetSubNavbarXmlElements())
            {
                var sitemapNode = new SiteMapNode(subNav);

                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var url = urlHelper.AbsoluteAction(sitemapNode.Action, sitemapNode.Controller);

                subNavBuilder.AppendLine("<li><a href=\"" + url + "\"><span style=\"margin-right:5px;\" class=\"" +
                                         sitemapNode.CssClass + "\"></span>" + sitemapNode.Display + "</a></li>");
            }

            subNavBuilder.AppendLine("</ul>");
            return subNavBuilder.ToString();
        }
    }
}