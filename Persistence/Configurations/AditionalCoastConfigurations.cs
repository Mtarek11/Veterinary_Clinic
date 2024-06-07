using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class AditionalCoastConfigurations : IEntityTypeConfiguration<AditionalCoast>
    {
        public void Configure(EntityTypeBuilder<AditionalCoast> builder) 
        {
            builder.ToTable("AditionalCoasts");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired(true);
            builder.Property(i => i.Description).IsRequired(true);
            builder.Property(i => i.CoastDate).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}