using System.ComponentModel.DataAnnotations;

namespace RestaurantApi23.Models.AppUser.Requests
{
    public class UserRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
