using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class SaleGameConfig : IEntityTypeConfiguration<SaleGame>
    {
        public void Configure(EntityTypeBuilder<SaleGame> builder)
        {
            builder.ToTable("wired_sale_game");
            //builder.HasKey(x => x.Id);
            builder.Property(x => x.SalePrice).IsRequired();

            //builder.HasOne(x => x.Game)
                
            //    .HasForeignKey(x => x.GameID);
        }
    }
}
