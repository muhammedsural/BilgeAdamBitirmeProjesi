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
    public class CartItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");
                entity.HasExtended();

                entity.Property(x => x.quantity).IsRequired(true);

                builder.Entity<CartItem>().HasOne(i => i.Cart).WithMany(i => i.CartItem).HasForeignKey(i => i.CartId);
                builder.Entity<CartItem>().HasOne(i => i.product).WithMany(i => i.cartItems)
                    .HasForeignKey(i => i.productId);
               
            });
        }
    }
}