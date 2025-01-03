using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public enum Role { 
            Registered,
            WebsiteAdmin,
            HotelAdmin
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Please enter a valid email address. An example could be account1@example.com.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(64, ErrorMessage = "Please do not enter values over 64 characters")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public required string Password { get; set; }
        public Role? UserRole { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking>? Bookings{ get; set; }
    }
}
