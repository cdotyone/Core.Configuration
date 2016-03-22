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
                return _coreConfig;
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
    }
}
