using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TreatmentMaterial : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public virtual Treatment Treatment { get; set; }
        public string TreatmentId {  get; set; }
        public virtual Material Material { get; set; }
        public string MaterialId {  get; set; }
        public double MaterialCount {  get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
