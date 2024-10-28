using System.ComponentModel.DataAnnotations;

namespace test_mvc.Models.DTOs;

public class ProductUpdate
{
    

    public int Id { get; set; }
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên phải từ 3-100 ký tự")]
    public string Name { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "Danh mục sản phẩm là bắt buộc")]
    public int CategoryId { get; set; }
}