using Domain;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Treatment : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public string Name { get; set; }
        public double Coast { get; set; } 
        public virtual ICollection<TreatmentMaterial> TreatmentMaterials { get; set; }
        public virtual ICollection<CustomerTreatment> CustomerTreatments { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    } 
}
