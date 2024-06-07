using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class PreviousCassAttachmentConfigurations : IEntityTypeConfiguration<PreviousCassAttachment>
    {
        public void Configure(EntityTypeBuilder<PreviousCassAttachment> builder)
        {
            builder.ToTable("PreviousCassAttachments");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Path).IsRequired(true);
            builder.Property(i => i.FileName).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
            builder.HasOne(i => i.PreviousCase).WithMany(i => i.PreviousCassAttachments).HasForeignKey(i => i.PreviousCaseId).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}