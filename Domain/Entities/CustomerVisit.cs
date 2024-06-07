using Domain;
using Domain.Comman;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CustomerVisit : BaseEntity, ISoftDeleteEntity, IAuditableEntity
    {
        public virtual Customer Customer { get; set; } 
        public string CustomerId { get; set; } 
        public string Description { get; set; }
        public VisitType VisitType { get; set; } 
        public string AdditionalTreatments {  get; set; }
        public double? AditionalTreatmentsCoast {  get; set; }
        public DateOnly VisitDate {  get; set; }
        public virtual ICollection<CustomerTreatment> CustomerTreatments {  get; set; }
        public virtual ICollection<CustomerVisitAttachment> CustomerVisitAttachments {  get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
