using Microsoft.EntityFrameworkCore;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("wired_images_game");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImagePath).HasMaxLength(255).IsRequired();
            builder.HasOne(x => x.Game)
                .WithMany(g => g.Images)
                .HasForeignKey(x => x.GameId);
        }
    }
}
