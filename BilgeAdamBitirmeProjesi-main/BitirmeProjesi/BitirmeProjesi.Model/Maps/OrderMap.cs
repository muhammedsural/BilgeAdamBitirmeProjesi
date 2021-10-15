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
    public class OrderMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasExtended();

                entity.Property(x => x.customerFirstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.customerSurname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.customerEmail).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.customerPhone).HasMaxLength(32);
                entity.Property(x => x.paymentTypeName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentProviderCode).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentProviderName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentGatewayCode).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentGatewayName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.bankName).HasMaxLength(128);
                entity.Property(x => x.clientIp).HasMaxLength(32).IsRequired(true);
                entity.Property(x => x.userAgent).HasMaxLength(1024);
                entity.Property(x => x.amount).IsRequired(true);
                entity.Property(x => x.taxAmount).IsRequired(true);
                entity.Property(x => x.shippingAmount).IsRequired(true);
                entity.Property(x => x.finalAmount).IsRequired(true);
                entity.Property(x => x.transactionId).HasMaxLength(255);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.deviceType).IsRequired(true);
                entity.Property(x => x.memberGroupName).HasMaxLength(255);
                entity.Property(x => x.shippingProviderCode).HasMaxLength(128);
                entity.Property(x => x.shippingProviderName).HasMaxLength(128);
                entity.Property(x => x.shippingCompanyName).HasMaxLength(128);
                entity.Property(x => x.shippingPaymentType);
                entity.Property(x => x.shippingTrackingCode).HasMaxLength(255);
                builder.Entity<OrderItem>().HasOne(i => i.Order).WithMany(i => i.orderItemsId)
                    .HasForeignKey(i => i.orderId);
            });
        }
    }
}