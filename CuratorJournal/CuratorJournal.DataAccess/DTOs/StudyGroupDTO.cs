//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuratorJournal.DataAccess.DTOs
{
    
    public partial class StudyGroupDTO
    {
    
        public int StudyGroupId { get; set; }
        public string DirectionAbbreviation { get; set; }
        public string SpecializationAbbreviation { get; set; }
        public int Course { get; set; }
        public System.DateTime DateCreate { get; set; }
        public bool IsBuget { get; set; }
        public string FullName { get; set; }
        public bool IsStudyComplieted { get; set; }
    }
}
