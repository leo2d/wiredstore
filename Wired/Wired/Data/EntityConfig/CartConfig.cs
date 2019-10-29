using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("wired_cart");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Games)
                .WithOne(c => c.Cart);

            builder.HasOne(x => x.Customer)
                .WithOne()
                .HasForeignKey<Cart>(x => x.CustomerId);
        }
    }

}
