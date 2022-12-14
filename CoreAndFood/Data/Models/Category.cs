using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The category name is not empty !")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }    
        public List<Food> Foods { get; set; }
    }
}
