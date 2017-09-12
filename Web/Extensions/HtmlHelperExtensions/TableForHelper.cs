using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Helpers;

namespace Web.Extensions.HtmlHelperExtensions
{
    /// <summary>
    /// MEMO: Approach used is not thread safe
    /// </summary>
    public static class TableForHelper
    {
        private static readonly IDictionary<int,string> CustomColumnsList = new Dictionary<int, string>();

        public static IHtmlString TableFor(this HtmlHelper helper, Type typeOf, string tableId)
        {
            return helper.Raw(GetTable(typeOf, tableId));
        }

        private static string GetTable(Type typeOf, string tableId)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<table id=\'" + tableId + "\' class=\'table table-bordered table-hover\'>");
            builder.AppendLine(GetTableHeader(typeOf));
            builder.AppendLine(GetTableBody());
            builder.AppendLine("</table>");
            return builder.ToString();
        }

        private static string GetTableHeader(Type typeOf)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<thead>")
                .AppendLine("<tr>");

            var currentColumnIndex = 0;

            foreach (var prop in typeOf.GetProperties())
            {
                foreach (var customColumn in CustomColumnsList)
                {
                    if (currentColumnIndex == customColumn.Key)
                    {
                        builder.Append(customColumn.Value);
                    }
                }

                if (!prop.IsPropertyACollection() && !prop.PropertyType.IsPrimitive)
                {
                    var displayName = AttributeHelper.GetPropertyDisplayName(prop) ?? prop.Name;
                    builder.Append($"<th>{displayName}</th>");
                    currentColumnIndex++;
                }
            }

            builder.AppendLine("</tr>")
                .AppendLine("</thead>");

            return builder.ToString();
        }

        private static string GetTableBody()
        {
            return "<tbody></tbody>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="atIndex"></param>
        /// <param name="customClass"></param>
        /// <param name="customInnerHtml"></param>
        public static HtmlHelper WithCustomColumn(this HtmlHelper helper, int atIndex, string customClass, string customInnerHtml)
        {
            if (!CustomColumnsList.ContainsKey(atIndex))
            {
                var customColumn = new KeyValuePair<int, string>(atIndex, "<th class='" + customClass + "'>" + customInnerHtml + "</th>");
                CustomColumnsList.Add(customColumn);
            }
            return helper;
        }

        public static HtmlHelper WithCustomColumn(this HtmlHelper helper, int atIndex, string customInnerHtml)
        {
            if (!CustomColumnsList.ContainsKey(atIndex))
            {
                var customColumn = new KeyValuePair<int, string>(atIndex, "<th>" + customInnerHtml + "</th>");
                CustomColumnsList.Add(customColumn);
            }
            return helper;
        }
    }
}