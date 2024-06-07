using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    { 
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired(true);
            builder.Property(i => i.PhoneNumber).IsRequired(true);
            builder.Property(i => i.DateOfBirth).IsRequired(false);
            builder.Property(i => i.IsDeleted).HasDefaultValue(false);
        }
    }
}