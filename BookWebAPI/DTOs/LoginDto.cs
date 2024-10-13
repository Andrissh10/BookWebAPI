using System.ComponentModel.DataAnnotations;

namespace BookWebApplicationWithAuthentication2.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
