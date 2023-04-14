using System.ComponentModel.DataAnnotations;

namespace Assignment1Group26.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int ClientId { get; set; }
        public int BidId { get; set; }
        public int SellerId { get; set; }

        public double TotalPaid { get; set; }


    }
}
