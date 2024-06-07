using Domain.Comman;

namespace Domain.Entities
{
    public class CustomerVisitAttachment : BaseFile, ISoftDeleteEntity
    {
        public virtual CustomerVisit CustomerVisit { get; set; }
        public string CustomerVisitId { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
