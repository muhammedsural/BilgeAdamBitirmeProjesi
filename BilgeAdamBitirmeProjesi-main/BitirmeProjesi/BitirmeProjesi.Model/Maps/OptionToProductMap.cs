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
    public class OptionToProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OptionToProduct>(entity =>
            {
                entity.ToTable("OptionToProducts");
                entity.HasExtended();
            });
        }
    }
}