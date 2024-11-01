using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(200)]
        public required string Address { get; set; }
        public string? Description{ get; set; }

        
        public string? ImageUrl { get; set; }
        [Required]
        [Range(50, 3000)]
        public double Size { get; set; }

        public DateTime? UpdatedBy { get; set; }

    }
}
