using Microsoft.EntityFrameworkCore;
using Wired.Data.EntityConfig;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Data.Contexts
{
    public class WiredContext : DbContext//IdentityDbContext<User>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GameKey> GameKeys { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        public WiredContext(DbContextOptions<WiredContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new GameKeyConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new GameKeyConfig());
            modelBuilder.ApplyConfiguration(new CartItemConfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new AdministratorConfig());
            modelBuilder.ApplyConfiguration(new PromoCodeConfig());
        }

        public DbSet<Wired.Models.ViewModels.PromoCodeViewModel> PromoCodeViewModel { get; set; }
    }
}
