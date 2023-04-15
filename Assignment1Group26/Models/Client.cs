using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

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
        public string? ClientUserNameWithoutAt { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6-10 characters long")]
        public string? ClientPassword { get; set; }
        [NotMapped]
        public string? ClientRetypePassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? ClientRole { get; set; }
        public bool Blocked { get; set; } = false;
        [NotMapped]
        public int? FirstNumber { get; set; }
        [NotMapped]
        public int? SecondNumber { get; set; }
        [NotMapped]
        public int? ThirdNumber { get; set; }
        [NotMapped]
        public int? FourthNumber { get; set; }
        [NotMapped]
        public int? FifthNumber { get; set; }
        [NotMapped]
        public int? SixthNumber { get; set; }
        public int MultiPin { get; set; } = 11111111;
        public string? VerficationToken { get; set; }
        public bool keepLoggedIn { get; set; }
        
     [StringLength(10,ErrorMessage = "Please enter your phone number")]
     public string? ClientPhoneNumber { get; set; }

     [Required(ErrorMessage = "Please enter your date of birth")]
     public DateTime? ClientBirthDate{ get; set; }
        
     public byte[]? ClientImage { get; set; }

     [NotMapped]
     [ValidateImage]

     public IFormFile? ImageFile { get; set; }


     public async Task SaveImageAsync()
     {
         if (ImageFile != null && ImageFile.ContentType.Contains("image"))
         {

             using (var ms = new MemoryStream())
             {
                 await ImageFile.CopyToAsync(ms);

                 ClientImage = ms.ToArray();
                 //ImageData = Convert.ToBase64String(data);   
             }

         }
         else if (ImageFile == null)
         {
             // If no new file was uploaded but there is  an existing image,
             // assign the existing image  to the ImagePath property.
             ClientImage = ClientImage;
         }
     }
     public class ValidateImage : ValidationAttribute
     {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
         {
             var client = (Client)validationContext.ObjectInstance;
                
                 if (client.ClientImage == null  )
                 {
                    if ( client.ImageFile == null) {

                        return ValidationResult.Success;
                    }
                }


             return ValidationResult.Success;
         }
     }






       


    }
}
