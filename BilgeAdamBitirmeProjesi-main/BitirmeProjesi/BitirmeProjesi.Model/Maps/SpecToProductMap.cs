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
    public class SpecToProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<SpecToProduct>(entity =>
            {
                entity.ToTable("SpecToProducts");
                entity.HasExtended();
            });
        }
    }
}