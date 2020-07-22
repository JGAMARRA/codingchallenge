using System.Configuration;

namespace Services.Config
{
    public class Config
    {
        private const string MISSING_CONFIGURATION = "Error en Key";

        public static string GetFromConfiguration(string key)
        {
            string configurationValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(MISSING_CONFIGURATION.Replace("{Key}", key));

            return configurationValue;
        }
    }
}
