using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Services.Interfaces;

public interface IProductService
{
    Task CreateProduct(ProductCreate product);
    Task<IEnumerable<Product>> ListProducts();
    
    Task Delete(int id);
    Task Update(ProductUpdate product);
    Task<Product?> Get(int id);
}