using caraspproject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllWithBrand();
        IEnumerable<Car> FindWithBrand(Func<Car, bool> predicate);
        IEnumerable<Car> FindWithBrandAndCustomer(Func<Car, bool> predicate);
    }
}
