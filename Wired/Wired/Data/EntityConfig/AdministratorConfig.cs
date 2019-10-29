using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class AdministratorConfig : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("wired_admin");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Email).IsFixedLength().HasMaxLength(100).IsRequired();
            //builder.Property(x => x.Password).IsFixedLength().HasMaxLength(255).IsRequired();
        }
    }
}
