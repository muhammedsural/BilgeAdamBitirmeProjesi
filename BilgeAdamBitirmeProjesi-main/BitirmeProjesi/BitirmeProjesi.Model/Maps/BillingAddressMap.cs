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
    public class BillingAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<BillingAddress>(entity =>
            {
                entity.ToTable("BillingAddresses");
                entity.HasExtended();

                entity.Property(x => x.firstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.surname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.country).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.location).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.subLocation).HasMaxLength(128);
                entity.Property(x => x.address).IsRequired(true);
                entity.Property(x => x.phonenumber).HasMaxLength(32);
                entity.Property(x => x.mobilePhonenumber).HasMaxLength(32).IsRequired(true);
                entity.Property(x => x.invoiceType).HasMaxLength(10).IsRequired(true);
                entity.Property(x => x.taxNo).IsRequired(true);
                entity.Property(x => x.taxOffice).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.identityRegistrationnumber).IsRequired(true);
            });
        }
    }
}