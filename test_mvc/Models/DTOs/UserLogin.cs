using System.ComponentModel.DataAnnotations;

namespace test_mvc.Models.DTOs;

public class UserLogin
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }    
}