using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Helpers;

namespace Web.Extensions.HtmlHelpers
{
    public static class TableForHelper
    {
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

            foreach (var prop in typeOf.GetProperties())
            {
                if (!prop.IsPropertyACollection() && !prop.PropertyType.IsPrimitive)
                {
                    var displayName = GetDisplayName(prop) ?? prop.Name;
                    builder.Append("<th>" + displayName + "</th>");
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
        
        private static string GetDisplayName(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property), @"Property does not have [Display Name] defined");

            var isDisplayNameAttributeDefined = Attribute.IsDefined(property, typeof(DisplayNameAttribute));

            if (isDisplayNameAttributeDefined)
            {
                return property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .Cast<DisplayNameAttribute>()
                    .Single()
                    .DisplayName;
            }
            return null;
        }
    }
}