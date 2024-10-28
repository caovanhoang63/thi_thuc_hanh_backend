using System.ComponentModel.DataAnnotations;
using test_mvc.Utils;

namespace test_mvc.Models.Entities;

public class Product : BaseEntity 
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    
    public string Image { get; set; }
    
    // Navigation Property
    public virtual Category Category { get; set; }
    
}
