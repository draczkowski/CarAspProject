using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Model
{
    public class Brand
    {
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public int BrandId { get; set; }
        public string Age { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
