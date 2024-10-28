using System.ComponentModel.DataAnnotations;

namespace test_mvc.Models.DTOs;

public class ProductCreate
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên phải từ 3-100 ký tự")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }

    public string Description { get; set; }
    public string Image { get; set; }
    
    [Required(ErrorMessage = "Danh mục sản phẩm là bắt buộc")]
    public int CategoryId { get; set; }
}