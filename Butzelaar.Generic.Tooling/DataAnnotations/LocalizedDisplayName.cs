using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Generic.Tooling.DataAnnotations
{
    /// <summary>
    /// This class supports use of resource files
    /// </summary>
    public class LocalizedDisplayName : DisplayNameAttribute
    {
        /// <summary>
        /// The _name property
        /// </summary>
        private PropertyInfo _nameProperty;
        /// <summary>
        /// The _resource type
        /// </summary>
        private Type _resourceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedDisplayName"/> class.
        /// </summary>
        /// <param name="displayNameKey">The display name key.</param>
        public LocalizedDisplayName(string displayNameKey)
            : base(displayNameKey)
        {
        }

        /// <summary>
        /// Gets or sets the type of the name resource.
        /// </summary>
        /// <value>
        /// The type of the name resource.
        /// </value>
        public Type NameResourceType
        {
            get
            {
                return _resourceType;
            }
            set
            {
                _resourceType = value;
                _nameProperty = _resourceType.GetProperty(base.DisplayName, BindingFlags.Static | BindingFlags.Public);
            }
        }

        /// <summary>
        /// Gets the display name for a property, event, or public void method that takes no arguments stored in this attribute.
        /// </summary>
        /// <returns>The display name.</returns>
        public override string DisplayName
        {
            get
            {
                if (_nameProperty == null)
                {
                    return base.DisplayName;
                }

                return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }

    }
}
