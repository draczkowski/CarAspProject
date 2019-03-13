using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Model
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Age { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
