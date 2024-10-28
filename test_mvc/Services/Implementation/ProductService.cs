using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;
using test_mvc.Services.Interfaces;

namespace test_mvc.Services.Implementation;

public class ProductService : IProductService
{
    
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task CreateProduct(ProductCreate product)
    {
         this._productRepository.Create(product).Wait();
         return Task.CompletedTask;
    }

    public Task<IEnumerable<Product>> ListProducts()
    {
        return this._productRepository.List();
    }

    public async Task Delete(int id)
    {
       await this._productRepository.Delete(id);
    }

    public async Task Update(ProductUpdate product)
    {
        await this._productRepository.Update(product);
    }

    public  async Task<Product?> Get(int id)
    {
       return  await this._productRepository.Get(id);
    }
    
}