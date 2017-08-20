using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
                builder.Append("<th>" + prop.Name + "</th>");
            }

            builder.AppendLine("</tr>")
                .AppendLine("</thead>");

            return builder.ToString();
        }

        private static string GetTableBody()
        {
            return "<tbody></tbody>";
        }
    }
}