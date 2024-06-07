using Domain;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AditionalCoast : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CoastDate {  get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get ; set ; }
    }
}
