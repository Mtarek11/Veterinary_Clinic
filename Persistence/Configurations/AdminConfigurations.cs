using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class AdminConfigurations : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        { 
            builder.ToTable("Admins");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Email).IsRequired(true);
            builder.Property(i => i.PasswordHash).IsRequired(true);
            builder.Property(i => i.RefreshToken).IsRequired(false);
            builder.Property(i => i.RefreshTokenEndDate).IsRequired(false);
            builder.HasIndex(i => i.RefreshToken).IsUnique(true);
        }
    }
}