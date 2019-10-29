using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleSheduler.WPF.BL
{

    public class MyDataGridProperty<T>
    {
        public string BDName;
        public string TableName;

        public Visibility Visibility;
        public bool IsReadOnly;

        public IEnumerable<T> ItemsSource;

        public MyDataGridProperty()
        {

        }

        public MyDataGridProperty(string bDName, string tableName, Visibility visibility, bool isReadOnly)
        {
            BDName = bDName;
            TableName = tableName;
            Visibility = visibility;
            IsReadOnly = isReadOnly;
        }
    }
}
