namespace Core.Configuration
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


        public const string CONFIG_CLIENTCODE_PROP = "client";
        public const string CONFIG_CLIENTCODE_DEFAULT = "CIVIC";

        public const string CONFIG_ENVCODE_PROP = "env";
        public const string CONFIG_ENVCODE_DEFAULT = "PROD";

        public const string CONFIG_APPNAME_PROP = "appname";
        public const string CONFIG_APPNAME_DEFAULT = "Unknown";

        internal class SR
    	{
    		public const string CONFIG_KEY_NULL = "ConfigHelper_Key_Null";
    	}
    }
}
