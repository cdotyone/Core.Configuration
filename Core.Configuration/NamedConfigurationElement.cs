using System.Collections.Generic;
using System.Xml;

namespace Core.Configuration
{
	/// <summary>
	/// A named element under configuration section
	/// </summary>
	public class NamedConfigurationElement : ConfigurationElement, INamedElement
    {
        private const string NAME = "name";
		private string _name;
		private const string VALUE = "value";
		private string _value;
        private string _checkSum = "";

        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
		private Dictionary<string, INamedElement> _children = new Dictionary<string, INamedElement>();

	    /// <summary>
		/// The name of the element or entry
		/// </summary>
        [ConfigurationProperty(NAME, IsKey = true, DefaultValue="Name", IsRequired = true)]
		[StringValidator(MinLength = 1)]
		public string Name {
			get
			{
				if (string.IsNullOrEmpty(_name)) _name = (string) this[NAME];
				return _name;
			}
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[ConfigurationProperty(VALUE, IsKey = false, IsRequired = false)]
		public string Value
		{
			get
			{
				if (string.IsNullOrEmpty(_value)) _value = (string)this[VALUE];
				return _value;
			}
			set { _value = value; }
		}

		public Dictionary<string, string> Attributes
		{
			get { return _attributes; }
            set
            {
                if (value != null) _attributes = value;
                else _attributes.Clear();
            }
        }

		public Dictionary<string, INamedElement> Children
		{
			get { return _children; }
		    set
		    {
		        if(value!=null)  _children = value;
		        else _children.Clear();
            }
		}

		public void DeserializeElement(XmlReader reader)
        {
            base.DeserializeElement(reader,false);
        }

	    public string CheckSum
	    {
	        get { return _checkSum; }
	    }
    }
}
