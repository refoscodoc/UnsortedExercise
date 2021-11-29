using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SakilaDotnet5.Models;

namespace SakilaDotnet5.DataAccessSqliteProvider
{
    public class DomainModelSqliteContext : DbContext
    {
        public DomainModelSqliteContext(DbContextOptions<DomainModelSqliteContext> options) : base(options)
        { }

        public DbSet<Actor> actor { get; set; }

        // public DbSet<SourceInfo> SourceInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor>().HasKey(m => m.actor_id);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<Actor>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}