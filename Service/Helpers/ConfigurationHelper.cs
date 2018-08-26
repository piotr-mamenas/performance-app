using System;
using System.Configuration;

namespace Service.Helpers
{
    public static class ConfigurationHelper
    {
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

        public static string AuthenticationServerUri
        {
            get
            {
                var authenticationServerUri = ConfigurationManager.AppSettings["authenticationServerUri"];
                if (authenticationServerUri == null)
                {
                    throw new ApplicationException("File Store path missing from Application Configuration");
                }
                return authenticationServerUri;
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