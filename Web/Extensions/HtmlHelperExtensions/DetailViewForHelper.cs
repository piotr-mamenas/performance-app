using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Helpers;

namespace Web.Extensions.HtmlHelperExtensions
{
    public static class DetailViewForHelper
    {
        private static readonly IDictionary<int, string> CustomHtmlList = new Dictionary<int, string>();
        private static readonly IDictionary<string, string> ButtonList = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <param name="detailViewId"></param>
        /// <param name="detailViewAction"></param>
        /// <returns></returns>
        public static IHtmlString DetailViewFor(this HtmlHelper helper, Type type, string detailViewId, string detailViewAction)
        {
            return helper.Raw(GetDetailView(type,detailViewId,detailViewAction));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="detailViewId"></param>
        /// <param name="detailViewAction"></param>
        /// <returns></returns>
        public static string GetDetailView(Type type, string detailViewId, string detailViewAction)
        {
           var detailViewBuilder = new StringBuilder();

            detailViewBuilder.AppendLine($"<div id =\"{detailViewId}\" class=\"col-md-8\">");
            detailViewBuilder.AppendLine("<form class=\"form-horizontal\" style=\"padding-left-30px; padding-right:30px;\">");

            var currentFormIndex = 0;

            foreach (var prop in type.GetProperties())
            {
                foreach (var customHtml in CustomHtmlList)
                {
                    if (currentFormIndex == customHtml.Key)
                    {
                        detailViewBuilder.Append(customHtml.Value);
                    }
                }

                if (!prop.IsPropertyACollection() && !prop.PropertyType.IsPrimitive)
                {
                    var displayName = AttributeHelper.GetPropertyDisplayName(prop) ?? prop.Name;
                    var controlId = char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1);

                    detailViewBuilder.AppendLine("<div class=\"form-group\">");
                    detailViewBuilder.AppendLine($"<label for=\"{controlId}\">{displayName}</label>");
                    detailViewBuilder.AppendLine($"<input type=\"test\" class=\"form-control\" id=\"{controlId}\"/>");
                    detailViewBuilder.AppendLine("</div>");
                }

                currentFormIndex++;
            }

            detailViewBuilder.AppendLine($"<button type=\"button\" class=\"btn btn-primary pull-right\">{detailViewAction}</button>");

            foreach (var additionalButton in ButtonList)
            {
                detailViewBuilder.AppendLine(
                    $"<button type=\"button\" class=\"btn btn-default pull-right\" id=\"{additionalButton.Key}\">{additionalButton.Value}</button>");
            }

            detailViewBuilder.AppendLine("</form>");
            detailViewBuilder.AppendLine("</div>");

            return detailViewBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="buttonId"></param>
        /// <param name="buttonDisplayText"></param>
        /// <returns></returns>
        public static HtmlHelper WithButton(this HtmlHelper helper, string buttonId, string buttonDisplayText)
        {
            var customButton = new KeyValuePair<string, string>(buttonId,buttonDisplayText);
            ButtonList.Add(customButton);
            return helper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="atIndex"></param>
        /// <param name="customInnerHtml"></param>
        /// <returns></returns>
        public static HtmlHelper WithCustomHtml(this HtmlHelper helper, int atIndex, string customInnerHtml)
        {
            var customHtml = new KeyValuePair<int, string>(atIndex, customInnerHtml);
            CustomHtmlList.Add(customHtml);
            return helper;
        }
    }
}