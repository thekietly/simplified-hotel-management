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

        [Display(Name = "Room description")]
        public string? Description{ get; set; }

        [Display(Name = "Max people")]
        public int Occupancy { get; set; }
        [Display(Name = "Number of beds")]
        public int Beds { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Price per night")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Room size in square meter")]
        public double Size { get; set; }

        public DateTime? UpdatedBy { get; set; }

    }
}
