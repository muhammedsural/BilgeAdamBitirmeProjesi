using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitirmeProjesi.Core.Map;
using BitirmeProjesi.Model.Entities;
using BitirmeProjesi.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Model.Maps
{
    public class CartMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasExtended();
            });
        }
    }
}