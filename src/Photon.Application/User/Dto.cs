using System.ComponentModel.DataAnnotations;

namespace Photon.Application.User
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Username { get; set; }
    };
}

