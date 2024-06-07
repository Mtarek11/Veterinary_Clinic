using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class CustomerVisitConfigurations : IEntityTypeConfiguration<CustomerVisit>
    {
        public void Configure(EntityTypeBuilder<CustomerVisit> builder)
        {
            builder.ToTable("CustomerVisits");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd(); 
            builder.Property(i => i.Description).IsRequired(true);
            builder.Property(i => i.VisitType).IsRequired(true);
            builder.Property(i => i.AdditionalTreatments).IsRequired(false);
            builder.Property(i => i.AditionalTreatmentsCoast).IsRequired(false);
            builder.Property(i => i.VisitDate).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
            builder.HasOne(i => i.Customer).WithMany(i => i.CustomerVisits).HasForeignKey(i => i.CustomerId).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}