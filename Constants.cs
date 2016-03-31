namespace Civic.Core.Configuration
{
    internal class Constants
    {
		public const string CONFIG_PROP_PROVIDER = "provider";
        public const string CORE_CONFIG_SECTION = "coreConfiguration";

    	public const string CONFIG_PROP_DEFAULTPROVIDER = "defaultProvider";
		public const string CONFIG_DEFAULTPROVIDER = "ConfigFile";
    	public const string CONFIG_PROP_PROVIDERS = "providers";
		public const string CONFIG_PROP_REDIRECTIONS = "redirections";

        // is the server in development mode
        public const string CONFIG_DEVMODE_PROP = "devMode";
        public const bool CONFIG_DEVMODE_DEFAULT = false;

        internal class SR
    	{
    		public const string CONFIG_KEY_NULL = "ConfigHelper_Key_Null";
    	}
    }
}
