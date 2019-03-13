using caraspproject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.ViewModel
{
    public class RentViewModel
    {
        public Car Car { get; set;  }
        public IEnumerable<Client> Clients { get; set; }
    }
}
