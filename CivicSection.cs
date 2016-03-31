using System.Configuration;

namespace Civic.Core.Configuration
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
            get { return (bool)base[Constants.CONFIG_DEVMODE_PROP]; }
            set { base[Constants.CONFIG_DEVMODE_PROP] = value; }
        }
    }
}
