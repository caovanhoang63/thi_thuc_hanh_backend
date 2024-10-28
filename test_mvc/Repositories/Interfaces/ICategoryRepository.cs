using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task Create(CategoryCreate product);
    Task<IEnumerable<CategoryList>> Category();
    
    Task Delete(int id);
    Task Update(CategoryUpdate product);
    Task<Category?> Get(int id);
}