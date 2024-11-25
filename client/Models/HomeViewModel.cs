using Domain.Entities;

namespace client.Models
{
    public class HomeViewModel
    {
        // List of hotels
        public IEnumerable<Hotel>? Hotels { get; set; }
        // Check in date
        public DateOnly CheckIn { get; set; }
        // Check out date
        public DateOnly CheckOut { get; set; }
        // Nights
        public int Nights { get; set; }
        // Created date
        public DateTime Created { get; set; }
        // Updated date
        public DateTime Updated { get; set; }

    }
}
