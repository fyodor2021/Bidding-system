namespace Assignment1Group26.Models
{
    public class ProfileReviewModel
    {
        public IEnumerable<Review>? Reviews { get; set; }
		public IEnumerable<Purchase>? purchases { get; set; }
		public IEnumerable<Client>? clients { get; set; }

		public Client? Client { get; set; }
        public Review? Review { get; set; }
    }
}
