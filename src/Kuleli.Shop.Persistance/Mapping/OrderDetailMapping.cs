﻿using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class OrderDetailMapping : AuditableEntityMapping<OrderDetail>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.OrderId)
                .HasColumnName("ORDER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.ProductId)          
               .HasColumnName("PRODUCT_ID")
               .HasColumnOrder(3);

            builder.Property(x => x.Quantity)               
               .HasColumnName("QUANTITY")
               .HasColumnOrder(4);

            builder.Property(x => x.TotalPrice)
              .HasColumnName("TOTAL_PRICE")
              .HasColumnOrder(5);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId)
                .HasConstraintName("ORDER_DETAILS_ORDER_ORDER_ID");
            

            builder.HasOne(x => x.Product)
               .WithMany(x => x.OrderDetails)
               .HasForeignKey(x => x.ProductId)
               .HasConstraintName("ORDER_DETAILS_PRODUCT_PRODUCT_ID");

            builder.ToTable("ORDER_DETAILS");

        }
    }
}
