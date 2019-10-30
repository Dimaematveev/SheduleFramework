using System.Collections.Generic;
using System.Windows;

namespace SimpleSheduler.WPF.BL
{
    public class MyColumnProperty
    {
        /// <summary>
        /// Название колонки из БД
        /// </summary>
        public string ColumnBDName;
        /// <summary>
        /// Название колонки при выводе
        /// </summary>
        public string ColumnOutName;

        /// <summary>
        /// Свойство колонки видимость
        /// </summary>
        public Visibility Visibility;
        /// <summary>
        /// Свойство колонки только для чтения?
        /// </summary>
        public bool IsReadOnly;
        /// <summary>
        /// Если не простое значение а выбор значений
        /// </summary>
        public IEnumerable<object> ItemsSource;

        public MyColumnProperty()
        {

        }

        public MyColumnProperty(string columnBDName):this(columnBDName, columnBDName,Visibility.Visible,false,null)
        {
        }

        public MyColumnProperty(string columnBDName, string columnOutName) : this(columnBDName, columnOutName, Visibility.Visible, false, null)
        {
        }

        public MyColumnProperty(string columnBDName, string columnOutName, Visibility visibility) : this(columnBDName, columnOutName, visibility, false, null)
        {
        }
        public MyColumnProperty(string columnBDName, string columnOutName, Visibility visibility, bool isReadOnly) : this(columnBDName, columnOutName, visibility, isReadOnly, null)
        {
          
        }

        public MyColumnProperty(string columnBDName, string columnOutName, Visibility visibility, bool isReadOnly, IEnumerable<object> itemsSource)
        {
            ColumnBDName = columnBDName;
            ColumnOutName = columnOutName;
            Visibility = visibility;
            IsReadOnly = isReadOnly;
            ItemsSource = itemsSource;
        }
    }
}
