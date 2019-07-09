using Interface.Interface;
using System.Collections.Generic;

public static class ____Информация
{
    static List<string> s = new List<string>();
    public static void Data()
    {
        const int smesh = 20;
        s.Add($"Что вообще делать");
        s.Add($"Делаем стандартные интерфейсы");
        s.Add($"{typeof(IGroup).Name,smesh} Начально готов.");
        s.Add($"{typeof(ISubject).Name,smesh} Начально готов.");
        s.Add($"{typeof(ISubjectOfTeacher).Name,smesh} Начально готов.");
        s.Add($"{typeof(ITeacher).Name,smesh} Начально готов.");
        s.Add($"{typeof(IPerson).Name,smesh} Начально готов.");
        s.Add($"{typeof(ITimeLessons).Name,smesh} Начально готов.");
        s.Add($"{typeof(ITypeLessons).Name,smesh} Начально готов.");
        s.Add($"{typeof(ISubjectTypeLessons).Name,smesh} Пока не знаю");
        s.Add($"{typeof(ISemestr).Name,smesh} Начально готов.");
        s.Add($"{typeof(IDaysOfStudy).Name,smesh} Начально готов.");
        s.Add($"{typeof(IPlanOfLessons).Name,smesh} Начально готов.");
        s.Add($"{typeof(IStudent).Name,smesh} Начально готов.");
        s.Add($"{typeof(IClassRoom).Name,smesh} Начально готов.");
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
