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
    public class CustomerTreatmentConfigurations : IEntityTypeConfiguration<CustomerTreatment>
    {
        public void Configure(EntityTypeBuilder<CustomerTreatment> builder)
        {
            builder.ToTable("CustomerTreatmentss");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.HasOne(i => i.CustomerVisit).WithMany(i => i.CustomerTreatments).HasForeignKey(i => i.CustomerVisitId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.Treatment).WithMany(i => i.CustomerTreatments).HasForeignKey(i => i.TreatmentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}