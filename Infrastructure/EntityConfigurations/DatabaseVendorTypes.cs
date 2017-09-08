using System.Configuration;

namespace Infrastructure.EntityConfigurations
{
    public static class DatabaseVendorTypes
    {
        public static string TimestampField
        {
            get
            {
                var configuration = ConfigurationManager.AppSettings["databaseServer"];

                if (configuration == "SQLServer")
                {
                    return "datetime2";
                }
                return null;
            }
        }
    }
}
