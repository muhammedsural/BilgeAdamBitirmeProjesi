using BitirmeProjesi.Core.Map;
using BitirmeProjesi.Model.Entities;
using BitirmeProjesi.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Model.Maps
{
    public class CountryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Countrys");
                entity.HasExtended();

                entity.Property(x => x.name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.status).IsRequired(true);
            });
        }
    }
}