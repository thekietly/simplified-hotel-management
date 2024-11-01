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

        [Range(1, 8)]
        public int Occupancy { get; set; }

        [Range(1, 5)]
        public int Beds { get; set; }

        public string? ImageUrl { get; set; }
        [Required]
        [Range(50, 10000)] // I don't want to stay in a room that's more expensive than this (p/s I'm using aud currency system) even if I'm a millionaire :)
        public double Price { get; set; }
        [Required]
        [Range(50, 3000)]
        public double Size { get; set; }

        public DateTime? UpdatedBy { get; set; }

    }
}
