using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [EnableCors("EveryOne")]
    [Route("api/cars")]
    public class CarController : Controller
    {
        private static DbContextOptionsBuilder<Context> _context;
        public CarController()
        {
            _context = new DbContextOptionsBuilder<Context>();
            _context.UseInMemoryDatabase();
        }

        [HttpGet]
        public List<Models.Car> Get()
        {
            using (var context = new Context(_context.Options))
            {
                return context.Car.Include(x => x.Brand).ToList();
            }
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            using (var context = new Context(_context.Options))
            {
                return context.Car.Include(x => x.Brand).First(x => x.Id == id);
            }
        }

        [HttpPut("{id}")]
        public void Put([FromRoute]int id, [FromBody]Car value)
        {
            using (var context = new Context(_context.Options))
            {
                var car = context.Car.First(x => x.Id == id);
                car.Name = value.Name;
                context.SaveChanges();
            }
        }
    }
}
