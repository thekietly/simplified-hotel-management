using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HotelRoom
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Description{ get; set; }

        public int Occupancy { get; set; }
        public int Beds { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Size { get; set; }

        public DateTime? UpdatedBy { get; set; }

    }
}
