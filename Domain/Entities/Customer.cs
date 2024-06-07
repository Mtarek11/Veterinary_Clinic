using Domain;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    { 
        public string Name { get; set; }  
        public string PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; } 
        public virtual ICollection<CustomerVisit> CustomerVisits { get; set; }
        public bool IsDeleted { get ; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
