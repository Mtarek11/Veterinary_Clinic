using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations 
{
    public class TreatmentConfigurations : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.ToTable("Treatments");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd(); 
            builder.Property(i => i.Name).IsRequired(true);
            builder.Property(i => i.Coast).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}