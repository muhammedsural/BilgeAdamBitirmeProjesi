using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class CountrySeedData : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    name = "Türkiye",
                    status = true,
                    Id = 1
                }
            );
        }
    }
}