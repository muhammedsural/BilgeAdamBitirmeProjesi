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
    public class ProductCommentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComments");
                entity.HasExtended();

                entity.Property(x => x.title).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.content).IsRequired(true);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.rank).IsRequired(true);
                entity.Property(x => x.isAnonymous).IsRequired(true);
            });
        }
    }
}