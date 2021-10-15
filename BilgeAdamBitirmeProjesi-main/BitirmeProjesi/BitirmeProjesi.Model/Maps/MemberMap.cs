using System.Security.Principal;
using BitirmeProjesi.Core.Map;
using BitirmeProjesi.Model.Entities;
using BitirmeProjesi.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Model.Maps
{
    public class MemberMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Member>(entity =>
            {
                entity.ToTable("Members");
                entity.HasExtended();

                entity.Property(x => x.firstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.surname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.password).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.email).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.phonenumber).HasMaxLength(255);
                entity.Property(x => x.mobilePhonenumber).HasMaxLength(255);
                entity.Property(x => x.lastIp).HasMaxLength(255);
                entity.Property(x => x.allowedToCampaigns).HasMaxLength(255);
                entity.Property(x => x.deviceType).HasMaxLength(255);
                entity.HasOne(i => i.Parent)
                    .WithMany(i => i.Children)
                    .HasForeignKey(i => i.referredMemberId);
                entity.HasOne(i => i.Country).WithMany(i => i.Member)
                    .HasForeignKey(i => i.CountryId);
                entity.HasOne(i => i.Location).WithMany(i => i.Member)
                    .HasForeignKey(i => i.LocationId);
            });
        }
    }
}