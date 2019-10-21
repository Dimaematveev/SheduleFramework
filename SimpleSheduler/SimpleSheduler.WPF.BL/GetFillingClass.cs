using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.WPF.BL
{
    public class GetFillingClass
    {
        /// <summary>
        /// Получить заполнение по каждому (преподавателю,группе,аудитории)
        /// </summary>
        /// <typeparam name="T">(преподавателю,группе,аудитории)</typeparam>
        /// <param name="array">массив (преподавателю,группе,аудитории)</param>
        /// <param name="pairs"> массив пар</param>
        /// <param name="studyDays">Массив учебных дней</param>
        /// <returns>массив заполнение по каждому (преподавателю,группе,аудитории)</returns>
        public static Filling<T>[] GetFilling<T>(T[] array, Pair[] pairs, StudyDay[] studyDays) where T : class, IName
        {
            var result = new List<Filling<T>>();
            foreach (var item in array)
            {
                result.Add(new Filling<T>(item, pairs, studyDays));
            }
            return result.ToArray();
        }
    }
}
