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
    using System;
    using System.Collections.Generic;
    
    public partial class PersonDTO
    {
    
        public int PersonId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNumber { get; set; }
        public string WhoGavePassport { get; set; }
        public System.DateTime WhenGetPassport { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public byte[] Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
