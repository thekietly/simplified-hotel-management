
using System.ComponentModel.DataAnnotations;
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

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
