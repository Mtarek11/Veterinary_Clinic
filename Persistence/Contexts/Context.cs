using Domain.Comman;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Configurations;
using Persistence.DataSeedings;

namespace Persistence.Contexts
{
    public class Context(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<AditionalCoast> AditionalCoasts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerVisit> CustomerVisits { get; set; }
        public DbSet<CustomerVisitAttachment> CustomerVisitAttachments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialSuppling> MaterialSupplings { get; set; }
        public DbSet<PreviousCase> PreviousCases { get; set; }
        public DbSet<PreviousCassAttachment> PreviousCassAttachments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<CustomerTreatment> CustomerTreatments {  get; set; }
        public DbSet<TreatmentMaterial> TreatmentMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AditionalCoastConfigurations());
            modelBuilder.ApplyConfiguration(new AdminConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerVisitConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerVisitAttachmentConfigurations());
            modelBuilder.ApplyConfiguration(new MaterialConfigurations());
            modelBuilder.ApplyConfiguration(new MaterialSupplingConfigurations());
            modelBuilder.ApplyConfiguration(new PreviousCaseConfigurations());
            modelBuilder.ApplyConfiguration(new PreviousCassAttachmentConfigurations());
            modelBuilder.ApplyConfiguration(new TreatmentConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerTreatmentConfigurations());
            modelBuilder.ApplyConfiguration(new TreatmentMaterialConfigurations());
            modelBuilder.SeedUsers();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker
                .Entries().Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified);

            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry.State == EntityState.Modified && modifiedEntries is IAuditableEntity)
                    ((IAuditableEntity)modifiedEntry.Entity).LastModifiedOn = DateTime.UtcNow;
            }

            var addedEntries = ChangeTracker
                .Entries().Where(x => x.Entity is BaseEntity && x.State == EntityState.Added);

            foreach (var addedEntry in addedEntries)
            {
                if (addedEntry.State == EntityState.Added)
                    ((IAuditableEntity)addedEntry.Entity).CreatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
