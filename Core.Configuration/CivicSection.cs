using System.Configuration;

namespace Core.Configuration
{

    public class CivicSection : Section
    {
        /// <summary>
        /// The current configuration for the configuration library
        /// </summary>
        public static CivicSection Current
        {
            get
            {
                if (_coreConfig == null) _coreConfig = (CivicSection) ConfigurationManager.GetSection(SectionName);
                if (_coreConfig != null) return _coreConfig;
                return new CivicSection();
            }
        }

        private static CivicSection _coreConfig;


        /// <summary>
        /// The name of the configuration section.
        /// </summary>
        public static string SectionName
        {
            get { return "civic"; }
        }


        /// <summary>
        /// Gets or sets if the site is in UI development mode
        /// </summary>
        [ConfigurationProperty(Constants.CONFIG_DEVMODE_PROP, IsRequired = false, DefaultValue = Constants.CONFIG_DEVMODE_DEFAULT)]
        public bool DevelopmentMode
        {
            get
            {
                var val = GetAttribute(Constants.CONFIG_DEVMODE_PROP,"false"); 
                return val=="true";
            }
            set { base[Constants.CONFIG_DEVMODE_PROP] = value; }
        }

        [ConfigurationProperty(Constants.CONFIG_CLIENTCODE_PROP, IsRequired = false)]
        public string ClientCode
        {
            get { return GetAttribute(Constants.CONFIG_CLIENTCODE_PROP, Constants.CONFIG_CLIENTCODE_DEFAULT); }
            set { base[Constants.CONFIG_CLIENTCODE_PROP] = value; }
        }

        [ConfigurationProperty(Constants.CONFIG_ENVCODE_PROP, IsRequired = false)]
        public string EnvironmentCode
        {
            get { return GetAttribute(Constants.CONFIG_ENVCODE_PROP, Constants.CONFIG_ENVCODE_DEFAULT); }
            set { base[Constants.CONFIG_ENVCODE_PROP] = value; }
        }

        [ConfigurationProperty(Constants.CONFIG_APPNAME_PROP, IsRequired = false)]
        public string ApplicationName
        {
            get { return GetAttribute(Constants.CONFIG_APPNAME_PROP, Constants.CONFIG_APPNAME_DEFAULT); }
            set { base[Constants.CONFIG_APPNAME_PROP] = value; }
        }

        public string GetAttribute(string name, string defaultValue)
        {
            if (Attributes.ContainsKey(name)) return Attributes[name];
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[name])) return defaultValue;
            return ConfigurationManager.AppSettings[name];
        }
    }
}
