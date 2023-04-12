using Stripe.Issuing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1Group26.Models
{
    public class BidsPlaced
    {
        [Key]
        public int BidsPlacedId { get; set; }
        [Required]
        public int BidId { get; set; }
        public int ClientId { get; set; }
        public double BidAmount { get; set; }
        public DateTime BidDate { get; set; } = DateTime.Now;

    }
}
