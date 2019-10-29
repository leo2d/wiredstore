using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("wired_cart_item");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Amount);
            builder.HasOne(c => c.Cart)
                .WithMany(x => x.Games)
                .HasForeignKey(c => c.CartID);

            builder.HasOne(c => c.Game)
                .WithOne()
                .HasForeignKey<CartItem>(c => c.GameID);
        }
    }
}
