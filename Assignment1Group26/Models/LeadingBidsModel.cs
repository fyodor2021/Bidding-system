namespace Assignment1Group26.Models
{
	public class LeadingBidsModel
	{
		public IEnumerable<BidsPlaced>? BidsPlaced { get; set; }
		public IEnumerable<Bid>? Bids { get; set; }


		public double? ElectronicSpending { get; set; }
		public double? ClothesSpending { get; set; }
		public double? CarsSpending { get; set; }
		public double? TotalBiddingAmount { get; set; }
		public Bid? Bid { set; get; }
		public Client? Client { set; get; }
		public BidsPlaced? BidPlaced { set; get; }
	}



}
