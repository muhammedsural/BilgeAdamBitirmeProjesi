using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class RegionSeedData : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(
                new Region
                {
                    name = "Marmara",
                    Id = 1
                }, new Region
                {
                    name = "Akdeniz",
                    Id = 2
                }, new Region
                {
                    name = "Karadeniz",
                    Id = 3
                }, new Region
                {
                    name = "Ege",
                    Id = 4
                }, new Region
                {
                    name = "Doğu Anadolu",
                    Id = 5
                }, new Region
                {
                    name = "Güney Doğu Anadolu",
                    Id = 6
                }
            );
        }
    }
}