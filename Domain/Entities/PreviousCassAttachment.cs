using Domain.Comman;

namespace Domain.Entities
{
    public class PreviousCassAttachment : BaseFile, ISoftDeleteEntity
    {
        public virtual PreviousCase PreviousCase { get; set; }
        public string PreviousCaseId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
