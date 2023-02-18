using System.ComponentModel.DataAnnotations;

namespace Assignment1Group26.Models
{
    public class AssetCondition
    {
        [Key]
        public int AssetConditionId { get; set; }
        
        public string AssetConditionName { get; set; }
    }
}
