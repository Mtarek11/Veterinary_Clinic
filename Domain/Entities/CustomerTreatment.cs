using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerTreatment : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public virtual CustomerVisit CustomerVisit {  get; set; }
        public string CustomerVisitId {  get; set; }
        public virtual Treatment Treatment { get; set; }
        public string TreatmentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? LastModifiedOn { get; set; }
    }
}
