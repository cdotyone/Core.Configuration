﻿using System.Collections.Generic;

namespace Core.Configuration
{
    public class DataConfig : NamedConfigurationElement
    {
        protected const string DEFAULT_CONNECTION_STRING = "default";
        private static CoreSection _coreConfig;
        private static DataConfig _current;
        private string _default;
        private Dictionary<string, string> _claimsDefaults;

        public DataConfig(INamedElement element)
        {
            if (element == null) element = new NamedConfigurationElement() {Name = SectionName };
            Children = element.Children;
            Attributes = element.Attributes;
            Name = element.Name;

            if(Attributes.ContainsKey(DEFAULT_CONNECTION_STRING)) _default = Attributes[DEFAULT_CONNECTION_STRING];
        }

        /// <summary>
        /// The current configuration for the audit library
        /// </summary>
        public static DataConfig Current
        {
            get
            {
                if (_current != null) return _current;

                if (_coreConfig == null) _coreConfig = CoreSection.Current;
                _current = new DataConfig(_coreConfig.Children.ContainsKey(SectionName) ? _coreConfig.Children[SectionName] : null);
                return _current;
            }
        }

        /// <summary>
        /// The name of the configuration section.
        /// </summary>
        public static string SectionName
        {
            get { return "data"; }
        }

        public string GetConnectionName(string name)
        {
            var connectionName = name;

            if (Children.ContainsKey("connection"))
            {
                var attributes = Children["connection"].Attributes;
                connectionName = attributes.ContainsKey(name) ? attributes[name] : _default;
            } else if (!string.IsNullOrEmpty(_default)) return _default;

            return string.IsNullOrEmpty(connectionName) ? name : connectionName;
        }

        public string GetSchemaName(string name)
        {
            var schemaName = name;

            if (Children.ContainsKey("schema"))
            {
                var attributes = Children["schema"].Attributes;
                schemaName = attributes.ContainsKey(name) ? attributes[name] : null;
            }
            return string.IsNullOrEmpty(schemaName) ? name : schemaName;
        }

        public Dictionary<string, string> DefaultClaims
        {
            get { return _claimsDefaults; }
            set { _claimsDefaults = value; }
        }
    }
}

