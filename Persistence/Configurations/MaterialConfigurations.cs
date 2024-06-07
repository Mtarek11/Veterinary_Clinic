using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class MaterialConfigurations : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder) 
        {
            builder.ToTable("Materials");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd(); 
            builder.Property(i => i.Name).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}
