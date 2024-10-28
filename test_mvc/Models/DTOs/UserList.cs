using System.ComponentModel.DataAnnotations;
using test_mvc.Models.Entities;
using test_mvc.Utils;

namespace test_mvc.Models.DTOs;

public class UserList : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 5)]
    public string UserName { get; set; }

    [Required]
    public UserRole UserRole { get; set; }
}