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
        [Required]
        public string Address { get; set; }
        public string? Description{ get; set; }
        public string? PhoneNumber { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public double size { get; set; }

    }
}
