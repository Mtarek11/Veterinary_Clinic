using Domain;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PreviousCase : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PreviousCassAttachment> PreviousCassAttachments { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
} 
