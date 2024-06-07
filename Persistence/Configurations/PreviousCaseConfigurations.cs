using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class PreviousCaseConfigurations : IEntityTypeConfiguration<PreviousCase>
    {
        public void Configure(EntityTypeBuilder<PreviousCase> builder)
        {
            builder.ToTable("PreviousCases");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd(); 
            builder.Property(i => i.Title).IsRequired(true);
            builder.Property(i => i.Description).IsRequired(true);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}
