using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(o => o.TotalAmount)
                .HasPrecision(18, 2);
            builder.Property(o=>o.ShippingAddress)
                .IsRequired()
                .HasMaxLength(300);
            builder.HasMany(o => o.Items)
                .WithOne(c => c.Order)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
