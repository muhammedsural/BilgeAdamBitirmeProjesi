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
    public class OrderUserNoteMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderUserNote>(entity =>
            {
                entity.ToTable("OrderUserNotes");
                entity.HasExtended();

                entity.Property(x => x.userEmail).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.userFirstname).HasMaxLength(255);
                entity.Property(x => x.userSurname).HasMaxLength(255);
                entity.Property(x => x.note);
            });
        }
    }
}