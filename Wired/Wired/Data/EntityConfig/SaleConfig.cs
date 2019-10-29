using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("wired_sale");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
            builder.Property(x => x.Total);
            builder.HasOne(x => x.CreditCard)
                .WithMany()
                .HasForeignKey(x => x.CreditCardId);
            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.PromoCode)
                .WithMany()
                .HasForeignKey(x => x.PromoCodeId);

        }
    }
}
