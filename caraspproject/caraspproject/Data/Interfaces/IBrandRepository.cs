using caraspproject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> GetAllWithCars();
        Brand GetWithCars(int id);
    }
}
