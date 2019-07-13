using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Attributes
{
    /// <summary>
    /// Атрибут для интерфейсов. Показывает готовность интерфейса.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ReadMetaDataInterfaceAttribute : Attribute
    {
        /// <value> Имя интерфейса. </value>
        public string Name;
        /// <value>Что делает интерфейс.</value>
        public string About;
        /// <value> Готовность интерфейса.</value>
        public string Readiness;
        /// <summary>
        /// Конструктор атрибута.
        /// </summary>
        /// <param name="name"> Имя интерфейса.</param>
        /// <param name="about">Что делает интерфейс.</param>
        /// <param name="readiness">Готовность интерфейса. Автоматически "Не делал".</param>
        public ReadMetaDataInterfaceAttribute(string name, string about, string readiness = "Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }

    /// <summary>
    /// Атрибут для свойств. Показывает готовность свойства.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ReadMetaDataPropertyAttribute : Attribute
    {
        /// <value> Имя свойства. </value>
        public string Name;
        /// <value>Что делает свойство.</value>
        public string About;
        /// <value> Готовность свойства.</value>
        public string Readiness;
        /// <summary>
        /// Конструктор атрибута.
        /// </summary>
        /// <param name="name"> Имя свойства.</param>
        /// <param name="about">Что делает свойство.</param>
        /// <param name="readiness">Готовность свойства. Автоматически "Не делал".</param>
        public ReadMetaDataPropertyAttribute(string name, string about, string readiness = "Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }

    /// <summary>
    /// Атрибут для методов. Показывает готовность метода.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ReadMetaDataMethodAttribute : Attribute
    {
        /// <value> Имя метода. </value>
        public string Name;
        /// <value>Что делает метод.</value>
        public string About;
        /// <value> Готовность метода.</value>
        public string Readiness;
        /// <summary>
        /// Конструктор атрибута.
        /// </summary>
        /// <param name="name"> Имя метода.</param>
        /// <param name="about">Что делает метод.</param>
        /// <param name="readiness">Готовность метода. Автоматически "Не делал".</param>
        public ReadMetaDataMethodAttribute(string name, string about, string readiness = "Не делал!!!")
        {
            Name = name;
            About = about;
            Readiness = readiness;
        }
    }
}
