using Interface.Attributes;
using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ____Информация
{
    static List<string> s = new List<string>();
    static List<IntarfacePropertyMetod> lis = new List<IntarfacePropertyMetod>();
    public static void Data()
    {
        const int smesh = 4;
        s.Add($"Что вообще делать");
        s.Add($"Делаем стандартные интерфейсы");
        var interfaces = new List<System.Type>()
        {
            typeof(IConsole),
            typeof(IGroup),
            typeof(ITeacher),
            typeof(ISubject),
            typeof(ISubjectOfTeacher),
            typeof(IPerson),
            typeof(ITimeLessons),
            typeof(ITypeLessons),
            typeof(ISubjectTypeLessons),
            typeof(ISemester<IDaysOfStudy>),
            typeof(IDaysOfStudy),
            typeof(IPlanOfLessons),
            typeof(IStudent),
            typeof(IClassRoom)
        };
        s.Add($"Всего {interfaces.Count} интерфейсов.");
        foreach (var interfac in interfaces)
        {
            var pairInterface =new List<InterfaceValue>();
            foreach (ReadMetaDataInterfaceAttribute atrib in interfac.GetCustomAttributes(typeof(ReadMetaDataInterfaceAttribute), false))
            {
                pairInterface.Add(new InterfaceValue(interfac, atrib));
                s.Add($"{"",smesh}'{atrib.Name}' \n{"",smesh}   {atrib.About}");
            }


            int numbProp = 0;
            var pairProperty = new List<PropertyValue> ();
            s.Add( $"{"",2 * smesh}Имеет {numbProp} свойств.");
            int ind = s.Count - 1;
            foreach (System.Reflection.PropertyInfo props in interfac.GetProperties())
            {
                foreach (ReadMetaDataPropertyAttribute atrib in props.GetCustomAttributes(typeof(ReadMetaDataPropertyAttribute), false))
                {
                    pairProperty.Add(new PropertyValue(props, atrib));
                    s.Add($"{"",3*smesh}'{props.ToString()}' - {atrib.About}");
                    numbProp++;
                }
            }
            s[ind] = $"{"",2*smesh}Имеет {numbProp} свойств.";


            int numbMetod = 0;
            var pairMetod = new List<MethodValue>();
            s.Add($"{"",2 * smesh}Имеет {numbMetod} методов.");
            ind = s.Count - 1;
            foreach (System.Reflection.MethodInfo method in interfac.GetMethods())
            {
                foreach (ReadMetaDataMethodAttribute atrib in method.GetCustomAttributes(typeof(ReadMetaDataMethodAttribute), false))
                {
                    pairMetod.Add(new MethodValue(method, atrib));
                    s.Add($"{"",3*smesh}'{method.Name}':'{method.ToString()}' - {atrib.About}");
                    numbMetod++;
                }
            }
            
            s[ind] = $"{"",2*smesh}Имеет {numbMetod} методов.";
            lis.Add(new IntarfacePropertyMetod(pairInterface, pairProperty, pairMetod));
        }

        
    }
    public static string Main1()
    {
        Data();
        string ret = "";
        //foreach (var item in s)
        //{
        //    ret += item + "\n";
        //}
        ret += $"Всего {lis.Count} интерфейсов." + "\n";
        foreach (var item in lis)
        {
            ret += item.ToString() + "\n";
        }
        return ret;
    }
    public static void ToConsole()
    {
        Data();
        Console.WriteLine();

        Console.Write($"Всего ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{lis.Count}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" интерфейсов.");
        Console.WriteLine();

        foreach (var item in lis)
        {
            item.ToConsole();
        }
    }
    public class IntarfacePropertyMetod
    {
        List<InterfaceValue> interfacePair = new List<InterfaceValue>();
        List<PropertyValue> propertyPair = new List<PropertyValue>();
        List<MethodValue> metodPair = new List<MethodValue>();

        public IntarfacePropertyMetod(  List<InterfaceValue> interfacePair, 
                                        List<PropertyValue> propertyPair, 
                                        List<MethodValue> metodPair)
        {
            this.interfacePair = interfacePair;
            this.propertyPair = propertyPair;
            this.metodPair = metodPair;
        }

        public void ToConsole()
        {
            const int smesh = 3;
            foreach (var item in interfacePair)
            {
                item.ToConsole();
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{"",2 * smesh}Имеет ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{propertyPair.Count}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" свойств.");
            Console.WriteLine();

            foreach (var item in propertyPair)
            {
                item.ToConsole();
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{"",2 * smesh}Имеет ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{metodPair.Count}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" методов.");
            Console.WriteLine();

            foreach (var item in metodPair)
            {
                item.ToConsole();
            }
            Console.WriteLine();
            
        }
        public override string ToString()
        {
            const int smesh = 3;
            string ret = "";
            //ret += $"{"",smesh}Имеет {interfacePair.Count} интерфейсов.";
            //ret += "\n";
            foreach (var item in interfacePair)
            {
                ret+=$"{item.ToString()}";
                ret += "\n";
            }
            ret += $"{"",2 * smesh}Имеет {propertyPair.Count} свойств.";
            ret += "\n";
            foreach (var item in propertyPair)
            {
                ret += $"{item.ToString()}";
                ret += "\n";
            }
            ret += $"{"",2 * smesh}Имеет {metodPair.Count()} методов.";
            ret += "\n";
            foreach (var item in metodPair)
            {
                ret += $"{item.ToString()}";
                ret += "\n";
            }
            return ret;
        }
    }

    public class InterfaceValue
    {
        Type Type { get; set; }
        ReadMetaDataInterfaceAttribute InterfaceAttribute { get; set; }
        public InterfaceValue(Type type, ReadMetaDataInterfaceAttribute attribute)
        {
            Type = type;
            InterfaceAttribute = attribute;
        }
        public override string ToString()
        {
            const int smesh = 3;
            return $"{"",smesh}'{InterfaceAttribute.Name}' \n{"",smesh}   {InterfaceAttribute.About}";
        }
        public void ToConsole()
        {
            const int smesh = 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{ "",smesh}'");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{InterfaceAttribute.Name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"' \n{"",smesh}   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{ InterfaceAttribute.About}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{InterfaceAttribute.Readiness}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

    }
    public class PropertyValue
    {
        PropertyInfo PropertyType { get; set; }
        ReadMetaDataPropertyAttribute PropertyAttribute { get; set; }
        public PropertyValue(PropertyInfo type, ReadMetaDataPropertyAttribute attribute)
        {
            PropertyType = type;
            PropertyAttribute = attribute;
        }
        public void ToConsole()
        {
            const int smesh = 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{"",3 * smesh}'");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{PropertyType.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"' - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{PropertyAttribute.About}");
            Console.ForegroundColor = ConsoleColor.White;
            

            Console.WriteLine();
        }
        public override string ToString()
        {
            const int smesh = 3;
            return $"{"",3 * smesh}'{PropertyType.ToString()}' - {PropertyAttribute.About}"; ;
        }

    }
    public class MethodValue
    {
        MethodInfo MethodType { get; set; }
        ReadMetaDataMethodAttribute MethodAttribute { get; set; }
        public MethodValue(MethodInfo type, ReadMetaDataMethodAttribute attribute)
        {
            MethodType = type;
            MethodAttribute = attribute;
        }
        public void ToConsole()
        {
            const int smesh = 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{"",3 * smesh}'");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{MethodType.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"' - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{MethodAttribute.About}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public override string ToString()
        {
            const int smesh = 3;
            return $"{"",3 * smesh}'{MethodType.Name}':'{MethodType.ToString()}' - {MethodAttribute.About}";
        }
    }
}
