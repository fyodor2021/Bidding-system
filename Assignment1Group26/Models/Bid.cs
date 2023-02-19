using System.ComponentModel.DataAnnotations;

namespace Assignment1Group26.Models
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        [Required(ErrorMessage ="Please enter a valid name")]
        public string? BidName { get; set;}
        [Required(ErrorMessage = "Please enter a valid discription")]
        public string? BidDescription { get; set;}
        [Required(ErrorMessage = "Please enter a valid cost")]
        public int? BidCost { get; set; }
        [Required]
        public DateTime BidStartDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please enter a valid end date")]
        public DateTime BidEndDate { get; set;}

        [Range(1, 4,ErrorMessage ="Please select a valid condition")]
        public int AssetConditionId { get; set; }
        public AssetCondition? AssetCondition { get; set; }
        [Range(1,3,ErrorMessage ="Please select a valid category")]
        public int CategoryId { get; set; }

        public Client? Client { get; set; }
        public int ClientId { get; set; }

        public Category? Category { get; set; }



    }
}
