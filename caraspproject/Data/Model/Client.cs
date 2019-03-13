using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public int CarCount { get; set; }

    }
}
