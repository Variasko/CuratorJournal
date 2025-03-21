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
    
    public partial class Curator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curator()
        {
            this.CuratorCharacteristics = new HashSet<CuratorCharacteristic>();
            this.StudyGroups = new HashSet<StudyGroup>();
        }
    
        public int CuratorId { get; set; }
        public int PersonId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    
        public virtual TeacherCategory TeacherCategory { get; set; }
        public virtual Person Person { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuratorCharacteristic> CuratorCharacteristics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyGroup> StudyGroups { get; set; }
    }
}
