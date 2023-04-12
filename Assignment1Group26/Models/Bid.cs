using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1Group26.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        [Required(ErrorMessage = "Please enter a valid name")]
        public string? BidName { get; set; }
        [Required(ErrorMessage = "Please enter a valid discription")]
        public string? BidDescription { get; set; }
        [Required(ErrorMessage = "Please enter a valid cost")]
        public double? BidCost { get; set; }
        [ValidateDate]

        public DateTime BidStartDate { get; set; } = DateTime.Now;
        [NotMapped]
        public DateTime BidStartTime { get; set; }
        [ValidateDate]
        public DateTime BidEndDate { get; set; } = DateTime.Now.AddDays(1);

        [NotMapped]
        public DateTime BidEndTime { get; set;}

        [Range(1, 4, ErrorMessage = "Please select a valid condition")]
        public int AssetConditionId { get; set; }
        public AssetCondition? AssetCondition { get; set; }
        [Range(1, 3, ErrorMessage = "Please select a valid category")]
        public int CategoryId { get; set; }

        public Client? Client { get; set; }
        public int ClientId { get; set; }

        public Category? Category { get; set; }
        public bool Status { get; set; } = false;
        
        public byte[]? ImageData { get; set; }

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

                    ImageData = ms.ToArray();
                    //ImageData = Convert.ToBase64String(data);   
                }

            }
            else if (ImageFile == null)
            {
                // If no new file was uploaded but there is  an existing image,
                // assign the existing image  to the ImagePath property.
                ImageData = ImageData;
            }
        }
        public class ValidateImage : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var bid = (Bid)validationContext.ObjectInstance;
                string action = (bid.BidId == 0) ? "Add" : "Edit";

                if (action == "Add")
                {
                    if (bid.ImageFile == null || !(bid.ImageFile.ContentType.Contains("image")))
                    {

                        return new ValidationResult("An image file is required.");
                    }
                }
                else
                {
                    if ((bid.ImageData != null))
                    {
                        return ValidationResult.Success;
                    }
                }



                return ValidationResult.Success;
            }
        }
        public class ValidateDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var bid = (Bid)validationContext.ObjectInstance;
                var bidEndDate = bid.BidEndDate;

                if (bidEndDate < bid.BidStartDate)
                {
                    return new ValidationResult("Bid end date must be greater than bid start date.");
                }
               

                return ValidationResult.Success;
            }
        }
    }


}
