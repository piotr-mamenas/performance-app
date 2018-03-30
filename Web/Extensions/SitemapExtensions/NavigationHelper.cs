using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Core.Domain.Identity;

namespace Web.Extensions.SitemapExtensions
{
    // TODO: Temporary string appends, will rework to string.Format
    public static class NavigationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString GenerateRibbon(this HtmlHelper helper)
        {
            return helper.Raw(GetNavbar(helper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string GetNavbarHeader(XDocument node)
        {
            var sitemapNode = new SiteMapNode(node.GetHeaderXmlElement());
            var headerStringBuilder = new StringBuilder();

            headerStringBuilder.AppendLine("<div class=\"navbar-header\" >");
            headerStringBuilder.AppendLine("<a href=\"#\" data-toggle=\"collapse\" data-target=\"#" + sitemapNode.NavId + "\" class=\"navbar-brand\">" + sitemapNode.Display + "</a>");
            headerStringBuilder.AppendLine("</div>");
            return headerStringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GetNavbar(HtmlHelper helper)
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
            navbarStringBuilder.Append(helper.Partial("_NavbarAuth"));
            navbarStringBuilder.AppendLine("</nav>");
            navbarStringBuilder.AppendLine(GetSubNavbar(sitemap));

            return navbarStringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string GetNavigationItem(XElement node)
        {
            var siteMapNode = new SiteMapNode(node);
            var visibilityStyle = siteMapNode.Visible ? "" : "display: none;";

            return "<li class=\"dropdown\" style=\"" + visibilityStyle + "\">" + 
                "<a href=\"#\" data-toggle=\"collapse\" data-target=\"#" + siteMapNode.NavId + "\"><span style=\"margin-right:5px;\" class=\"" + siteMapNode.CssClass +
                "\"></span>" + siteMapNode.Display + "</a></li>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string GetSubNavbar(XDocument node)
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
        private static string GetSubNavigationItem(XElement node, string navId)
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