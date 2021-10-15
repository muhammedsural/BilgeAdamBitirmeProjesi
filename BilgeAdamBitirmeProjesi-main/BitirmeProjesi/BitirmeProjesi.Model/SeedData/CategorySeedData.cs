using BitirmeProjesi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BitirmeProjesi.Model.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    name = "A Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),

                    metaDescription = "A Segmenti Küçük Araçlar",
                    metaKeywords = "A Segmenti Küçük Araçlar",
                },
                new Category
                {
                    Id = 2,
                    name = "B Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),
                    metaDescription = "B Segmenti Küçük üst Araçlar",
                    metaKeywords = "B Segmenti Küçük Üst Araçlar",
                }, new Category
                {
                    Id = 3,
                    name = "C Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),
                    metaDescription = "C Segmenti Orta Araçlar",
                    metaKeywords = "C Segmenti Orta Araçlar",
                }, new Category
                {
                    Id = 4,
                    name = "D Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),
                    metaDescription = "D Segmenti Orta Üst Araçlar",
                    metaKeywords = "D Segmenti Orta üst Araçlar",
                },
                new Category
                {
                    Id = 5,
                    name = "E Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),
                    metaDescription = "E Segmenti  Üst Araçlar",
                    metaKeywords = "E Segmenti  üst Araçlar",
                },
                new Category
                {
                    Id = 6,
                    name = "S Segmenti",
                    status = true,
                    createdAt = DateTime.Now.AddDays(-300),
                    metaDescription = "S Segmenti  Üst Araçlar",
                    metaKeywords = "S Segmenti  üst Araçlar",
                }
            );
        }
    }
}