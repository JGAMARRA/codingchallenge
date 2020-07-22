namespace Services.Config
{
    public class ConfigGoogle:Config
    {
        public static string BaseUrl => GetFromConfiguration("Google.BaseUrl");
        public static string ApiKey => GetFromConfiguration("Google.ApiKey");
        public static string ContextId => GetFromConfiguration("Google.ContextId");
    }
}
