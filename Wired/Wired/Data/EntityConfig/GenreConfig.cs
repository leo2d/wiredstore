using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("wired_genre_game");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(45).IsRequired();
            builder.HasMany(x => x.Games)
                .WithOne(g => g.Genre)
                .HasForeignKey(g => g.GenreId);
        }
    
    }
}
