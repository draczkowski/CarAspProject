using caraspproject.Data.Interfaces;
using caraspproject.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(LibraryDbContext context) : base(context)
        {

        }
        public IEnumerable<Brand> GetAllWithCars()
        {
            return _context.Brands.Include(a => a.Cars);
        }

        public Brand GetWithCars(int id)
        {
            return _context.Brands
                .Where(a => a.BrandId == id)
                .Include(a => a.Cars)
                .FirstOrDefault();
        }
    }
}
