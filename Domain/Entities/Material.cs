using Domain;
using System;
using Domain.Comman;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Material : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MaterialSuppling> MaterialSupplings { get; set; }
        public virtual ICollection<TreatmentMaterial> TreatmentMaterials { get; set; }
        public bool IsDeleted { get ; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
