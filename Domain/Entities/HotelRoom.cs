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
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description{ get; set; }


        public int Occupancy { get; set; }

        public int Beds { get; set; }

        public string? ImageUrl { get; set; }
        [Required]
        [Range(50, 10000)] // I don't want to stay in a room that's more expensive than this even if I'm a millionaire :)
        public double Price { get; set; }
        [Required]

        public double Size { get; set; }

        public DateTime? UpdatedBy { get; set; }

    }
}
