using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class LocationSeedData : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    countryid = 1,
                    name = "İstanbul",
                    regionid = 1,
                    status = true,
                    Id = 1
                },
                new Location
                {
                    countryid = 1,
                    name = "İzmir",
                    regionid = 4,
                    status = true,
                    Id = 2
                }, new Location
                {
                    countryid = 1,
                    name = "Hakkari",
                    regionid = 6,
                    status = true,
                    Id = 3
                }
            );
        }
    }
}