using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class MaterialSupplingConfigurations : IEntityTypeConfiguration<MaterialSuppling>
    {
        public void Configure(EntityTypeBuilder<MaterialSuppling> builder)
        {
            builder.ToTable("MaterialSupplings");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.SupplyCount).IsRequired(true);
            builder.Property(i => i.SupplyPrice).IsRequired(true);
            builder.Property(i => i.SupplyDate).IsRequired(true);
            builder.HasOne(i => i.Material).WithMany(i => i.MaterialSupplings).HasForeignKey(i => i.MaterialId).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}