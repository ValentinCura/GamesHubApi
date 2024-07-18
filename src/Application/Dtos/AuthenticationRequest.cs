
using System.ComponentModel.DataAnnotations;


namespace Application.Dtos
{
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Rol { get; set; }
    }
}
