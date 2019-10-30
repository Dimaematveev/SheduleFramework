using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleSheduler.WPF.BL
{

    public class MyDataGridProperty
    {
        /// <summary>
        /// Список колонок
        /// </summary>
        public IEnumerable<MyColumnProperty> MyColumnProperties;

        /// <summary>
        /// Полное пространство имен из БД
        /// </summary>
        public string FullNamespaceBD;

        /// <summary>
        /// Название таблицы для вывода
        /// </summary>
        public string NameTable;

        public MyDataGridProperty()
        {
        }

        public MyDataGridProperty(IEnumerable<MyColumnProperty> myColumnProperties, string fullNamespaceBD, string nameTable)
        {
            MyColumnProperties = myColumnProperties;
            FullNamespaceBD = fullNamespaceBD;
            NameTable = nameTable;
        }
    }
}
