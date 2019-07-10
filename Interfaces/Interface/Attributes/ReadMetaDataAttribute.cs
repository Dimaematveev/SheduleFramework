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
        public string Readiness;

        public ReadMetaDataInterfaceAttribute(string name, string about, string readiness = "Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ReadMetaDataPropertyAttribute : Attribute
    {
        public string Name;
        public string About;
        public string Readiness;

        public ReadMetaDataPropertyAttribute(string name, string about, string readiness = "Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ReadMetaDataMethodAttribute : Attribute
    {
        public string Name;
        public string About;
        public string Readiness;

        public ReadMetaDataMethodAttribute(string name, string about,string readiness="Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }
}
