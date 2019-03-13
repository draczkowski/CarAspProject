using caraspproject.Data.Interfaces;
using caraspproject.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(LibraryDbContext context) : base(context)
        {

        }
        public IEnumerable<Car> FindWithBrand(Func<Car, bool> predicate)
        {
            return _context.Cars
                .Include(a => a.Brand)
                .Where(predicate);
        }

        public IEnumerable<Car> FindWithBrandAndCustomer(Func<Car, bool> predicate)
        {
            return _context.Cars
                 .Include(a => a.Brand)
                 .Include(a => a.Customer)
                 .Where(predicate);
        }

        public IEnumerable<Car> GetAllWithBrand()
        {
            return _context.Cars
                 .Include(a => a.Brand);
                 
        }
    }
}
