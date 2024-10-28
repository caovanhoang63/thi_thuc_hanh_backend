using System.ComponentModel.DataAnnotations;
using test_mvc.Utils;

namespace test_mvc.Models.Entities;

public class User:  BaseEntity
{
    
    [Required]
    public string UserName { get; set; }
}