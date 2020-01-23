using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AssecorTask.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssecorTask.Persistance.EF
{
    public class AssecorTaskDbContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<ColorEntity> Colors { get; set; }

        public AssecorTaskDbContext(DbContextOptions<AssecorTaskDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssecorTaskDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var createdEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            createdEntities.ForEach(e =>
            {
                var now = DateTime.UtcNow;
                e.Property(nameof(BaseEntity.CreationDate)).CurrentValue = now;
                e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = now;
            });

            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            editedEntities.ForEach(e =>
            {
                e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
