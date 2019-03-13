using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarPower { get; set; }
        public int CarAge { get; set; }
        public int CarSeats { get; set; }
        public String CarColor { get; set; }

        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }


        public virtual Client Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
