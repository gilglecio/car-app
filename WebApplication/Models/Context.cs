using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        
        public Context(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
                builder.HasOne(x => x.Car)
                .WithOne(x => x.Brand)
                .HasForeignKey<Car>(x => x.BrandId);
            });

            modelBuilder.Entity<Car>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            });
        }
    }
}
