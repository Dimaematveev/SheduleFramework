using Interface.Attributes;
using Interface.Interface;
using System.Collections.Generic;
using System.Linq;

public static class ____Информация
{
    static List<string> s = new List<string>();
    public static void Data()
    {
        const int smesh = 4;
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
            foreach (ReadMetaDataInterfaceAttribute atrib in interfac.GetCustomAttributes(typeof(ReadMetaDataInterfaceAttribute), false))
            {
                s.Add($"{"",smesh}'{atrib.Name}' \n{"",smesh}   {atrib.About}");
            }
            int numbProp = 0;
            s.Add( $"{"",2 * smesh}Имеет {numbProp} свойств.");
            int ind = s.Count - 1;
            foreach (System.Reflection.PropertyInfo props in interfac.GetProperties())
            {
                foreach (ReadMetaDataPropertyAttribute atrib in props.GetCustomAttributes(typeof(ReadMetaDataPropertyAttribute), false))
                {
                    s.Add($"{"",3*smesh}'{props.ToString()}' - {atrib.About}");
                    numbProp++;
                }
            }
            s[ind] = $"{"",2*smesh}Имеет {numbProp} свойств.";
            int numbMetod = 0;
            s.Add($"{"",2 * smesh}Имеет {numbMetod} методов.");
            ind = s.Count - 1;
            foreach (System.Reflection.MethodInfo method in interfac.GetMethods())
            {
                foreach (ReadMetaDataMethodAttribute atrib in method.GetCustomAttributes(typeof(ReadMetaDataMethodAttribute), false))
                {
                    s.Add($"{"",3*smesh}'{method.Name}':'{method.ToString()}' - {atrib.About}");
                    numbMetod++;
                }
            }
            s[ind] = $"{"",2*smesh}Имеет {numbMetod} методов.";
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
