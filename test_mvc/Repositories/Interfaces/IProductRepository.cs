using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Repositories.Interfaces;

public interface IProductRepository
{
    Task Create(ProductCreate product);
    Task<IEnumerable<Product>> List();
    Task Delete(int id);
    Task Update( ProductUpdate product);
    
    Task<Product?> Get(int id);
}