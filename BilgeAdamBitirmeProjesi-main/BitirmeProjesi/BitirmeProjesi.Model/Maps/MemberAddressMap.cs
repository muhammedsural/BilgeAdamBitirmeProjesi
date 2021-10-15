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
    public class MemberAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<MemberAddress>(entity =>
            {
                entity.ToTable("MemberAddresses");
                entity.HasExtended();

                entity.Property(x => x.adresType).HasMaxLength(255);
                entity.Property(x => x.firstname).HasMaxLength(255);
                entity.Property(x => x.surname).HasMaxLength(255);
                entity.Property(x => x.address);
                entity.Property(x => x.phonenumber).HasMaxLength(32);
                entity.Property(x => x.mobilePhonenumber).HasMaxLength(32);
                entity.Property(x => x.invoiceType).HasMaxLength(255);
                entity.Property(x => x.createdAt);
                entity.Property(x => x.updatedAt);
            });
        }
    }
}