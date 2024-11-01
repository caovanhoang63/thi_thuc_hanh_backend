using System.ComponentModel.DataAnnotations;
using test_mvc.Utils;

namespace test_mvc.Models.Entities;

public enum UserRole { Admin = 0, Customer = 1 }
public class User:  BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [StringLength(255, MinimumLength = 5)]
    public string UserName { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 8)]
    public string Password { get; set; }
    
    [Required]
    public UserRole UserRole { get; set; }
}