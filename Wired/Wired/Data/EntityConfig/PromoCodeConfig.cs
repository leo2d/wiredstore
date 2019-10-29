using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class PromoCodeConfig : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.ToTable("wired_promo_code");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.UsedAmount);
            builder.Property(x => x.Coupon).HasMaxLength(80).IsRequired();
            builder.Property(x => x.DiscountPercent).HasMaxLength(3).IsRequired();
        }
    }
}
