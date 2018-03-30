using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Web.Extensions.SitemapExtensions
{
    public static class SiteMapXmlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sitemapXml"></param>
        /// <returns></returns>
        public static IList<XElement> GetNavbarXmlElements(this XDocument sitemapXml)
        {
            return sitemapXml.Descendants()
                .Where(e => (string) e.Attribute("navigation") == "navbar")
                .ToList();
        }

        public static XElement GetHeaderXmlElement(this XDocument sitemapXml)
        {
            return sitemapXml
                .Descendants()
                .SingleOrDefault(e => (string) e.Attribute("navigation") == "page");
        }

        public static IList<XElement> GetSubNavbarXmlElements(this XElement navbarElement)
        {
            return navbarElement.Elements()
                .Where(e => (string) e.Attribute("navigation") == "subNav")
                .ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SiteMapNode
    {
        public SiteMapNode(XElement node)
        {
            Display = node.Attribute("display")?.Value;

            Action = node.Attribute("action")?.Value;

            Controller = node.Attribute("controller")?.Value;

            CssClass = node.Attribute("cssClass")?.Value;

            NavId = node.Attribute("navId")?.Value;

            Visible = node.Attribute("visible")?.Value != "false";
        }

        public string Display { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string CssClass { get; set; }

        public string NavId { get; set; }

        public bool Visible { get; set; }
    }
}