
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Domain.Entities
{
    public class Review
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Hotel")]
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
        [JsonIgnore]
        public virtual Hotel? Hotel { get; set; }
    }
}
