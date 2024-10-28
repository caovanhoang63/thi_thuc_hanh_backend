using System.ComponentModel.DataAnnotations;
using test_mvc.Utils;

namespace test_mvc.Models.Entities;

public class Category :BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    // Navigation Property (1-to-many)
    public virtual ICollection<Product> Products { get; set; }
}
