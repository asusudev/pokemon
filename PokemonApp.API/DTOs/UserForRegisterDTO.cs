using System.ComponentModel.DataAnnotations;

namespace PokemonApp.API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "you must specify password between 4 and 50 chars")]
        public string Password { get; set; }
    }
}