using caraspproject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.ViewModel
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Car> Cars { get; internal set; }
    }
}
