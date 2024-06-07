using Domain;
using System;
using Domain.Comman;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaterialSuppling : BaseEntity, IAuditableEntity
    {
        public virtual Material Material { get; set; }
        public string MaterialId { get; set; } 
        public double SupplyCount { get; set; }
        public double SupplyPrice {  get; set; } 
        public DateTime SupplyDate { get; set; }
        public DateTime CreatedOn { get; set; }  
        public DateTime? LastModifiedOn { get; set; }
    }
}
