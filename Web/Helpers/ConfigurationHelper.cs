using System;
using System.Configuration;

namespace Web.Helpers
{
    public static class ConfigurationHelper
    {
        public static string WebServerUri
        {
            get
            {
                var webServerUri = ConfigurationManager.AppSettings["webServerUri"];
                if (webServerUri == null)
                {
                    throw new ApplicationException("Web Server missing from Application Configuration");
                }
                return webServerUri;
            }
        }

        public static string FileStorePath
        {
            get
            {
                var filestoreUri = ConfigurationManager.AppSettings["filestoreUri"];
                if (filestoreUri == null)
                {
                    throw new ApplicationException("File Store path missing from Application Configuration");
                }
                return filestoreUri;
            }
        }

        public static string SessionCookieName
        {
            get
            {
                var sessionCookieName = ConfigurationManager.AppSettings["sessionCookieName"];
                if (sessionCookieName == null)
                {
                    throw new ApplicationException("Session Cookie Name missing from Application Configuration");
                }
                return sessionCookieName;
            }
        }
    }
}