using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class TreatmentMaterialConfigurations : IEntityTypeConfiguration<TreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<TreatmentMaterial> builder)
        {
            builder.ToTable("TreatmentMaterials");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.MaterialCount).IsRequired(true);
            builder.HasOne(i => i.Material).WithMany(i => i.TreatmentMaterials).HasForeignKey(i => i.MaterialId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.Treatment).WithMany(i => i.TreatmentMaterials).HasForeignKey(i => i.TreatmentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}
