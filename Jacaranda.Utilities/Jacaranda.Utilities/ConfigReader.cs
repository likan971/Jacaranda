using System;
using System.Configuration;

namespace Jacaranda.Utilities
{
    public static class ConfigReader
    {
        public static T GetAppSettings<T>(string key, T defaultValue = default(T))
        {
            var value = ConfigurationManager.AppSettings[key];

            if(value == null)
            {
                if(defaultValue != null)
                {
                    return defaultValue;
                }
                return default(T);
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

    }
}
