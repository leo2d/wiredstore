using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wired.Models.Entities;

namespace Wired.Data.EntityConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("wired_customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Cpf).IsFixedLength().HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).IsFixedLength().HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).IsFixedLength().HasMaxLength(255).IsRequired();
        }
    }
}