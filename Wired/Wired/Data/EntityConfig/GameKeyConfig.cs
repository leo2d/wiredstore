using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class GameKeyConfig : IEntityTypeConfiguration<GameKey>
    {
        public void Configure(EntityTypeBuilder<GameKey> builder)
        {
            builder.ToTable("wired_keys_game");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Key).HasMaxLength(255).IsRequired();
            builder.Property(x => x.IsUsed).HasColumnType("boolean").IsRequired();
            builder.HasOne(x => x.Game)
                .WithMany(g => g.Keys)
                .HasForeignKey(x => x.GameId);
        }
    }
}
