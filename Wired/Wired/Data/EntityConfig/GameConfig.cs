using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("wired_game");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(80).IsRequired();
            builder.Property(g => g.Producer).HasMaxLength(80).IsRequired();
            builder.Property(g => g.ReleaseYear).HasMaxLength(4).IsFixedLength().IsRequired();
            builder.Property(g => g.ShortDescription).HasMaxLength(255);
            builder.Property(g => g.Description).IsRequired();
            builder.Property(g => g.Price).IsRequired();
            builder.HasOne(g => g.Genre)
                .WithMany(g => g.Games)
                .HasForeignKey(g => g.GenreId);
        }
    }
}