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
    public class PaymentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");
                entity.HasExtended();

                entity.Property(x => x.memberFirstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.memberSurname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.memberEmail).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.memberPhone).HasMaxLength(255);
                entity.Property(x => x.paymentTypeName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentProviderCode).HasMaxLength(64).IsRequired(true);
                entity.Property(x => x.paymentProviderName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentGatewayName).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.paymentGatewayCode).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.bankName).HasMaxLength(64);
                entity.Property(x => x.deviceType).IsRequired(true);
                entity.Property(x => x.clientIp).HasMaxLength(32).IsRequired(true);
                entity.Property(x => x.currencyRates).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.amount).IsRequired(true);
                entity.Property(x => x.finalAmount).IsRequired(true);
                entity.Property(x => x.installment).IsRequired(true);
                entity.Property(x => x.installmentRate).IsRequired(true);
                entity.Property(x => x.currency).HasMaxLength(12).IsRequired(true);
                entity.Property(x => x.memberNote);
                entity.Property(x => x.userNote);
                entity.Property(x => x.status).IsRequired(true);
                entity.Property(x => x.errorMessage).IsRequired(true);
                entity.Property(x => x.cardSavingSystem).HasMaxLength(255);
            });
        }
    }
}