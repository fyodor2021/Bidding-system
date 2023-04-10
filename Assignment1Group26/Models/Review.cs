using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1Group26.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public int CreatedBy { get; set; }
        [Required]
        public string CreatedByStr { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
