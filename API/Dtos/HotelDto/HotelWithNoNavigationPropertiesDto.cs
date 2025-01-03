using System.ComponentModel.DataAnnotations;

namespace API.Dtos.HotelDto
{
    public class HotelWithNoNavigationPropertiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Size { get; set; }
    }
}
