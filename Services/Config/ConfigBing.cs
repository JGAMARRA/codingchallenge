namespace Services.Config
{
    public class ConfigBing:Config
    {
        public static string BaseUrl => GetFromConfiguration("Bing.BaseUrl");
        public static string ApiKey => GetFromConfiguration("Bing.ApiKey");
        public static string CustomKey => GetFromConfiguration("Bing.CustomConfig");
    }
}
