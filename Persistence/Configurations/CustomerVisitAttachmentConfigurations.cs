using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class CustomerVisitAttachmentConfigurations : IEntityTypeConfiguration<CustomerVisitAttachment>
    {
        public void Configure(EntityTypeBuilder<CustomerVisitAttachment> builder)
        {
            builder.ToTable("CustomerVisitAttachments");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.FileName).IsRequired(true); 
            builder.Property(i => i.Path).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
            builder.HasOne(i => i.CustomerVisit).WithMany(i => i.CustomerVisitAttachments).HasForeignKey(i => i.CustomerVisitId).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}