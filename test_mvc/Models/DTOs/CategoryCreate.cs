using System.ComponentModel.DataAnnotations;
using test_mvc.Models.Entities;

namespace test_mvc.Models.DTOs;

public class CategoryCreate
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}