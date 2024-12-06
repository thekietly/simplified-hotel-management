using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [Range(0, 10)]
        public int Location { get; set; }

        [Range(0, 10)]
        public int ValueForMoney { get; set; }

        [Range(0, 10)]
        public int Service { get; set; }

        [Range(0, 10)]
        public int Cleanliness { get; set; }

        [Range(0, 10)]
        public int Facilities { get; set; }

        [Range(0, 10)]
        public int RoomComfortAndQuality { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
