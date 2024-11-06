using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HotelRoom
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }


        [Key, Column(Order = 1)]
        public int RoomId { get; set; } // Room number within the hotel
        [Range(1, 8)]
        public int Occupancy { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Beds { get; set; }

        public string? ImageUrl { get; set; }
        [Required]
        [Range(50, 10000)] // I don't want to stay in a room that's more expensive than this (p/s I'm using aud currency system) even if I'm a millionaire :)
        public double Price { get; set; }
        public string? SpecialDetails { get; set; }


        public virtual Hotel Hotel { get; set; } = null!;
    }
}
