using System;

namespace Domain.Comman
{
    public class BaseFile : BaseEntity, IAuditableEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}