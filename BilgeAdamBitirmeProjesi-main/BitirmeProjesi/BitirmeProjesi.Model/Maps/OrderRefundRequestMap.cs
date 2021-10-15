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
    public class OrderRefundRequestMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderRefundRequest>(entity =>
            {
                entity.ToTable("OrderRefundRequests");
                entity.HasExtended();

                entity.Property(x => x.code).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.fee).IsRequired(true);
                entity.Property(x => x.cancellationReason).HasMaxLength(512);
            });
        }
    }
}