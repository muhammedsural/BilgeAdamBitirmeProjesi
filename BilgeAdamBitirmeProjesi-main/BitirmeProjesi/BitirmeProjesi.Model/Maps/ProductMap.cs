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
    public class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasExtended();

                entity.Property(x => x.name).HasMaxLength(255).IsRequired(true);

                entity.Property(x => x.fullName).HasMaxLength(255).IsRequired(true);

                entity.Property(x => x.price).IsRequired(true);
                entity.Property(x => x.stockTypeLabel);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.searchKeywords).HasMaxLength(255).IsRequired(true);
                entity.HasOne(i => i.brand)
                    .WithMany(i => i.products)
                    .HasForeignKey(i => i.brandId);
                entity.HasOne(i => i.category)
                    .WithMany(i => i.products)
                    .HasForeignKey(i => i.categoryId);
            });
        }
    }
}