using System.ComponentModel.DataAnnotations;

namespace Assignment1Group26.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }



    }
}
