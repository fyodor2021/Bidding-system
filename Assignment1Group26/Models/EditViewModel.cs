namespace Assignment1Group26.Models
{
    public class EditViewModel
    {
        public Bid bid { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<AssetCondition> conditions { get; set; }
    }
}
