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
    public class OptionGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OptionGroup>(entity =>
            {
                entity.ToTable("OptionGroups");
                entity.HasExtended();

                entity.Property(x => x.title).HasMaxLength(255).IsRequired(true);
            });
        }
    }
}