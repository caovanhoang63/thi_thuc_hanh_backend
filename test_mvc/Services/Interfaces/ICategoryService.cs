using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Services.Interfaces;

public interface ICategoryService
{
    Task Create(CategoryCreate product);
    Task<IEnumerable<CategoryList>> List();
    
    Task Delete(int id);
    Task Update(CategoryUpdate product);
    Task<Category?> Get(int id);
}