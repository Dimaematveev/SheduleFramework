//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudyDays
    {
        public int StudyDayId { get; set; }
        public string AbbreviationDayOfWeek { get; set; }
        public string FullNameDayOfWeek { get; set; }
        public Nullable<int> NumberDayOfWeek { get; set; }
        public int NumberOfWeek { get; set; }
    }
}