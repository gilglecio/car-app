using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class Seed
    {
        private static DbContextOptionsBuilder<Context> _context;

        public Seed()
        {
            _context = new DbContextOptionsBuilder<Context>();
            _context.UseInMemoryDatabase();

            BrandSeed();
            CarSeed();
        }

        private static void BrandSeed()
        {
            var brands = new List<Brand>();

            brands.Add(new Brand { Id = 1, Name = "BMW" });
            brands.Add(new Brand { Id = 2, Name = "Volkswagen" });
            brands.Add(new Brand { Id = 3, Name = "Chevrolet" });
            brands.Add(new Brand { Id = 4, Name = "Ford" });
            brands.Add(new Brand { Id = 5, Name = "Fiat" });
            brands.Add(new Brand { Id = 6, Name = "Mercedes" });

            using (var context = new Context(_context.Options))
            {
                context.Brand.AddRange(brands);
                context.SaveChanges();
            }

        }

        public void CarSeed()
        {
            var cars = new List<Car>();

            cars.Add(new Car { Id = 1, Name = "X6", Year = 2016, BrandId = 1 });
            cars.Add(new Car { Id = 2, Name = "X1", Year = 2015, BrandId = 1 });
            cars.Add(new Car { Id = 3, Name = "Golf GTI", Year = 2015, BrandId = 2 });
            cars.Add(new Car { Id = 4, Name = "Jetta", Year = 2016, BrandId = 2 });
            cars.Add(new Car { Id = 5, Name = "Cruze", Year = 2016, BrandId = 3 });
            cars.Add(new Car { Id = 6, Name = "Cobalt", Year = 2014, BrandId = 3 });
            cars.Add(new Car { Id = 7, Name = "Fusion", Year = 2015, BrandId = 4 });
            cars.Add(new Car { Id = 8, Name = "Edge", Year = 2015, BrandId = 4 });
            cars.Add(new Car { Id = 9, Name = "Bravo", Year = 2015, BrandId = 5 });
            cars.Add(new Car { Id = 10, Name = "Stilo", Year = 2011, BrandId = 5 });
            cars.Add(new Car { Id = 11, Name = "CLC 200", Year = 2016, BrandId = 6 });
            cars.Add(new Car { Id = 12, Name = "Classe A", Year = 2016, BrandId = 6 });

            using (var context = new Context(_context.Options))
            {
                context.Car.AddRange(cars);
                context.SaveChanges();
            }

        }
    }
}
