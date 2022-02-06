using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class DealershipContext : DbContext
    {
        public DbSet<Accessory> Acessories { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1LLACCK;Database=DealershipsManagement;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}