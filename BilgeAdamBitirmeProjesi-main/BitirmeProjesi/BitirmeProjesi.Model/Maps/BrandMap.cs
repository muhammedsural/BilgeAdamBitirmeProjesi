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
    public class BrandMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasExtended();
             
                entity.Property(x => x.name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.brandImage);
                entity.Property(x => x.pageTitle).HasMaxLength(255);
                entity.Property(x => x.createdAt);
                entity.Property(x => x.updatedAt);
                
            });
        }
    }
}