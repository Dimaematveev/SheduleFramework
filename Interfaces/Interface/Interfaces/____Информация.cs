using Interface.Attributes;
using Interface.Interface;
using System.Collections.Generic;
using System.Linq;

public static class ____Информация
{
    static List<string> s = new List<string>();
    public static void Data()
    {
        const int smesh = 20;
        s.Add($"Что вообще делать");
        s.Add($"Делаем стандартные интерфейсы");
        var interfaces = new List<System.Type>()
        {
            typeof(IGroup),
            typeof(ISubject),
            typeof(ISubjectOfTeacher),
            typeof(IPerson),
            typeof(ITimeLessons),
            typeof(ITypeLessons),
            typeof(ISubjectTypeLessons),
            typeof(ISemestr),
            typeof(IDaysOfStudy),
            typeof(IPlanOfLessons),
            typeof(IStudent),
            typeof(IClassRoom)
        };
        s.Add($"Всего {interfaces.Count} интерфейсов.");
        foreach (var interfac in interfaces)
        {
            var interfacesAttr = interfac.GetCustomAttributes(typeof(ReadMetaDataInterfaceAttribute), false);
            foreach (ReadMetaDataInterfaceAttribute atrib in interfacesAttr)
            {
                s.Add($"\t'{atrib.Name}' \n \t   {atrib.About}");
            }

            var propertysAttr = interfac.GetProperties().SelectMany(x => x.GetCustomAttributes(typeof(ReadMetaDataPropertyAttribute), false));
            s.Add($"\t\tИмеет {propertysAttr.Count()} свойств.");
            foreach (ReadMetaDataPropertyAttribute atrib in propertysAttr)
            {
                    s.Add($"\t\t\t'{atrib.Name}' - {atrib.About}");
                
            }

            var metodsAttr = interfac.GetMethods().SelectMany(x => x.GetCustomAttributes(typeof(ReadMetaDataMethodAttribute), false));
            s.Add($"\t\tИмеет {metodsAttr.Count()} методов.");
            foreach (ReadMetaDataMethodAttribute atrib in metodsAttr)
            {
                s.Add($"\t\t\t'{atrib.Name}' - {atrib.About}");
            }
        }
    }
    public static string Main1()
    {
        Data();
        string ret = "";
        foreach (var item in s)
        {
            ret += item + "\n";
        }
        return ret;
    }


}
