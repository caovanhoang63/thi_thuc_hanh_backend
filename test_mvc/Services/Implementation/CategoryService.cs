using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;
using test_mvc.Services.Interfaces;

namespace test_mvc.Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;
    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }
    public async Task Create(CategoryCreate product)
    {
        await _categoryRepo.Create(product);
    }

    public  async Task<IEnumerable<CategoryList>> List()
    {
        return await _categoryRepo.Category();
    }

    public async Task Delete(int id)
    {
        await this._categoryRepo.Delete(id);
    }

    public  async Task Update(CategoryUpdate product)
    {
        await this._categoryRepo.Update(product);
    }

    public async Task<Category?> Get(int id)
    {
        return await this._categoryRepo.Get(id);
    }
}