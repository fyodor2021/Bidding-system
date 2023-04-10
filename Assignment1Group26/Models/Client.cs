using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1Group26.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string? ClientFirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string? ClientLastName { get; set; }
        [Required]

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? ClientUserName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6-10 characters long")]
        public string? ClientPassword { get; set; }
        [NotMapped]
        public string? ClientRetypePassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? ClientRole { get; set; }
        public string? VerficationToken { get; set; }
        public bool keepLoggedIn { get; set; }
    }
}
