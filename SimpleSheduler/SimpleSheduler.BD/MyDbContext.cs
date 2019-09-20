using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Контекст базы данных - лучше приватный
    /// </summary>
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// Передаем будующую строку подключения
        /// </summary>
        protected MyDbContext() : base("DbConnectionString")
        {

        }
    }
}
