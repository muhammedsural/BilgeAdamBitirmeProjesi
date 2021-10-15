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
    public class OrderRefundRequestItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderRefundRequestItem>(entity =>
            {
                entity.ToTable("OrderRefundRequestItems");
                entity.HasExtended();

                entity.Property(x => x.amount).IsRequired(true);
                entity.Property(x => x.reason).HasMaxLength(1024).IsRequired(true);
                entity.Property(x => x.details).IsRequired(true);
            });
        }
    }
}