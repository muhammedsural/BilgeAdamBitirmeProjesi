using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.SeedData
{
    public class OrderItemSeedData : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasData(
                new OrderItem
                {
                    Id = 1,
                    orderId = 1,
                    productId = 1,
                    productName = "A",
                    productPrice = 11,
                    productQuantity = 1,
                    productTax = 1,
                    productStockTypeLabel = "Adet"
                }, new OrderItem
                {
                    Id = 2,
                    orderId = 2,
                    productId = 1,
                    productName = "A",
                    productPrice = 11,
                    productQuantity = 1,
                    productTax = 1,
                    productStockTypeLabel = "Adet"
                }, new OrderItem
                {
                    Id = 3,
                    orderId = 3,
                    productId = 1,
                    productName = "A",
                    productPrice = 11,
                    productQuantity = 1,
                    productTax = 1,
                    productStockTypeLabel = "Adet"
                }, new OrderItem
                {
                    Id = 4,
                    orderId = 4,
                    productId = 1,
                    productName = "A",
                    productPrice = 11,
                    productQuantity = 1,
                    productTax = 1,
                    productStockTypeLabel = "Adet"
                }
            );
        }
    }
}