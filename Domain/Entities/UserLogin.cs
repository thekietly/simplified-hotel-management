using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserLogin
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
