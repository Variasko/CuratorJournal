//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuratorJournal.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndividualWork
    {
        public int IndividualWorkId { get; set; }
        public bool IsStudent { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Topic { get; set; }
        public string Decision { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
    }
}
