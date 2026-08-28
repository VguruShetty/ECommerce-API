using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // You can add custom logic here before saving changes, such as auditing, validation, etc.
            foreach (var entry in ChangeTracker.Entries<BaseEntity<Guid>>())
            {  // Example: Set CreatedAt and UpdatedAt timestamps
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedAtUTC = DateTime.UtcNow;
                    }                
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
