using BitirmeProjesi.Core.Map;
using BitirmeProjesi.Model.Entities;
using BitirmeProjesi.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Model.Maps
{
    public class OrderItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.HasExtended();
                entity.Property(x => x.productName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.productPrice).IsRequired(true);
                entity.Property(x => x.productQuantity).IsRequired(true);
                entity.Property(x => x.productTax).IsRequired(true);
                entity.Property(x => x.productStockTypeLabel).HasMaxLength(255).IsRequired(true);
            });
        }
    }
}