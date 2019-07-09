using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ReadMetaDataInterfaceAttribute : Attribute
    {
        public string Name;
        public string About;

        public ReadMetaDataInterfaceAttribute(string name, string about)
        {
            Name = name;
            About = about;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ReadMetaDataPropertyAttribute : Attribute
    {
        public string Name;
        public string About;

        public ReadMetaDataPropertyAttribute(string name, string about)
        {
            Name = name;
            About = about;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ReadMetaDataMethodAttribute : Attribute
    {
        public string Name;
        public string About;

        public ReadMetaDataMethodAttribute(string name, string about)
        {
            Name = name;
            About = about;
        }
    }
}
