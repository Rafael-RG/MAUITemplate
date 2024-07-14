namespace Template.Common
{
    /// <summary>
    /// Constants used for in the app
    /// </summary>
    public static class Constants
    {
        public static string DatabaseName = "Template.db";

        public static string AzureDatabaseName = "Template.db";

        public static string ConnectionString = "";

        public const string BaseUri = "https://";

        public static string WebApiKeyHeader => "x-functions-key";

        public static string WebApiKey => (IsReleaseEnvironment) ? "WEB_API_KEY_PROPERTY" : "";

        public static string WebApiHost => (IsReleaseEnvironment) ? "WEB_API_HOST_PROPERTY" : "";
     
        public static string EnviromentName => (IsReleaseEnvironment) ? "ENVIRONMENT_NAME_PROPERTY" : "";
       
        public static string AppCenterDroid => (IsReleaseEnvironment) ? "APP_CENTER_DROID_PROPERTY" : "";

        public static string AppCenteriOS => (IsReleaseEnvironment) ? "APP_CENTER_IOS_PROPERTY" : "";

        public static bool IsReleaseEnvironment
        {
            get
            {
#if !DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}
