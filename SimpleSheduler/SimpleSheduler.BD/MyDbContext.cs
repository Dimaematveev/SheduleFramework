﻿using SimpleSheduler.BD.Model;
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
        /// Передаем будущую строку подключения
        /// </summary>
        public MyDbContext() :base("test_MINI")
        {
            Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
        }

        ~MyDbContext()
        {
            
        }
        ///Надо указать коллекции наборы данных которые будем использовать.
        ///Все таблицы что будем реализовывать
        ///

        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<StudyDay> StudyDays { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<TypeUnionGroup> TypeUnionGroups { get; set; }
    }
}
