using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    /// <summary>
    /// Учебный план включающий изменение кол-во пар и несколько учебных планов
    /// </summary>
    public class CurriculaWithAmountPair
    {
        

        /// <summary>
        /// Учебные планы которые объединились
        /// </summary>
        private Curriculum[] Curricula { get; set; }
        /// <summary>
        /// Количество пар за 2 недели
        /// </summary>
        public int NumberOfPair { get; private set; }
        /// <summary>
        /// Удачно ли последнее добавление то есть возможно ли добавлять еще
        /// </summary>
        private bool MaybeAdd { get; set; }

        public CurriculaWithAmountPair(Curriculum curriculum)
        {
            Curricula = new Curriculum[] { curriculum };
            NumberOfPair = curriculum.NumberOfPairs;
            if (NumberOfPair>0)
            {
                MaybeAdd = true;
            }
        }

        //Добавить 1 учебный план
        public bool AddCurriculum(Curriculum curriculum)
        {
            if (CheckAdd(curriculum))
            {
                return false;
            }
            var tempCurricula = new Curriculum[Curricula.Length+1];
            for (int i = 0; i < Curricula.Length; i++)
            {
                tempCurricula[i] = Curricula[i];
            }
            tempCurricula[Curricula.Length] = curriculum;
            Curricula = tempCurricula;
            return true;
        }
        
        //Добавить массив учебных планов
        public bool AddCurriculum(Curriculum[] curricula)
        {
            foreach (var curriculum in curricula)
            {
                if (!CheckAdd(curriculum))
                {
                    return false;
                }
            }
          
            var tempCurricula = new Curriculum[Curricula.Length + curricula.Length];
            for (int i = 0; i < Curricula.Length; i++)
            {
                tempCurricula[i] = Curricula[i];
            }
            for (int i = 0; i < curricula.Length; i++)
            {
                tempCurricula[Curricula.Length+i] = curricula[i];
            }
            Curricula = tempCurricula;
            return true;
        }
        public Group[] GetGroups()
        {
            List<Group> groups = new List<Group>();
            foreach (var curriculum in Curricula)
            {
                groups.Add(curriculum.Group);
            }
            return groups.ToArray();
        }
        public Subject GetSubject()
        {
            return Curricula[0].Subject;
        }
        public int[] GetCurriculumId()
        {
            List<int> curriculaId = new List<int>();
            foreach (var curriculum in Curricula)
            {
                curriculaId.Add(curriculum.CurriculumId);
            }
            return curriculaId.ToArray();
        }
        /// <summary>
        /// создать новый учебный план по подобию 
        /// </summary>
        /// <param name="ind"> индекс по которому создается</param>
        /// <param name="numberOfPairs"> сколько пар будет</param>
        /// <returns></returns>
        public Curriculum NewCurriculum(int ind,int numberOfPairs)
        {
            var newcul = new Curriculum()
            {
                CurriculumId = Curricula[ind].CurriculumId,
                Group = Curricula[ind].Group,
                GroupId = Curricula[ind].GroupId,
                Subject = Curricula[ind].Subject,
                SubjectId = Curricula[ind].SubjectId,
                NumberOfPairs = numberOfPairs
            };
            return newcul;
        }
        /// <summary>
        /// Получить количество планов
        /// </summary>
        /// <returns></returns>
        public int GetNumberPlan()
        {
            return Curricula.Length;
        }

        /// <summary>
        /// Убираем одну пару. т.е. она была заполнена
        /// </summary>
        public void RemoveOnePair()
        {
            NumberOfPair--;
            if (NumberOfPair == 0)
            {
                MaybeAdd = false;
            }
        }

        /// <summary>
        /// Проверка что можно объединить предметы
        /// </summary>
        /// <param name="curriculum">Учебный план</param>
        /// <returns>true или false</returns>
        private bool CheckAdd(Curriculum curriculum)
        {
            //Кол-во пар должно совпадать
            if (curriculum.NumberOfPairs != NumberOfPair)
            {
                return false;
            }
            //Предмет должен совпадать
            if (curriculum.SubjectId != Curricula[0].SubjectId)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string str = $"{NumberOfPair.ToString()} ({Curricula.Length})";
            foreach (var curriculum in Curricula)
            {
                str += $" {curriculum.ToString()}";
            }
            return str;
        }
    }
}
