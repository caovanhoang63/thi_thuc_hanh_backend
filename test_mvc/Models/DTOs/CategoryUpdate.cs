using System.ComponentModel.DataAnnotations;

namespace test_mvc.Models.DTOs;

public class CategoryUpdate
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}