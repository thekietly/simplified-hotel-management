using System.ComponentModel.DataAnnotations;

namespace hotel_management.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }    
    }
}
