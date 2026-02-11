using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDBContext : DbContext

    {
        private readonly DbContextOptions<ApplicationDBContext> _options;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            _options = options;
        }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<VehicleMaster> VehicleMasters { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Set precision for ExpectedPrice property
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.ExpectedPrice)
                .HasPrecision(18, 2);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Maruti Suzuki" },
                new Manufacturer { Id = 2, Name = "Hyundai" },
                new Manufacturer { Id = 3, Name = "Tata Motors" },
                new Manufacturer { Id = 4, Name = "Mahindra & Mahindra" },
                new Manufacturer { Id = 5, Name = "Honda Cars India" },
                new Manufacturer { Id = 6, Name = "Toyota Kirloskar" },
                new Manufacturer { Id = 7, Name = "Renault India" },
                new Manufacturer { Id = 8, Name = "Kia Motors" },
                new Manufacturer { Id = 9, Name = "Volkswagen India" },
                new Manufacturer { Id = 10, Name = "Skoda Auto India" },
                new Manufacturer { Id = 11, Name = "Nissan Motor India" },
                new Manufacturer { Id = 12, Name = "MG Motor India" },
                new Manufacturer { Id = 13, Name = "Ford India" },
                new Manufacturer { Id = 14, Name = "Fiat India" },
                new Manufacturer { Id = 15, Name = "Isuzu Motors India" },
                new Manufacturer { Id = 16, Name = "Force Motors" },
                new Manufacturer { Id = 17, Name = "Ashok Leyland" },
                new Manufacturer { Id = 18, Name = "Eicher Motors" },
                new Manufacturer { Id = 19, Name = "Bajaj Auto" },
                new Manufacturer { Id = 20, Name = "Hero MotoCorp" }
            );
        }


    }
}
