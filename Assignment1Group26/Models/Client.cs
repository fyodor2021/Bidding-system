using System.ComponentModel.DataAnnotations;

namespace Assignment1Group26.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public string? ClienFirstName { get; set; }
        [Required]
        public string? ClienLastName { get; set; }
        [Required]

        public string? ClientUserName { get; set; }
        [Required]
        public string? ClientPassword { get; set; }
        public bool keepLoggedIn { get; set; }
    }
}
