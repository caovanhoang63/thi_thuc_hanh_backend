using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test_mvc.Config;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;

namespace test_mvc.Repositories.EF;

public class ProductEFRepo : IProductRepository
{
    private readonly DbSet<Product> _productDbSet;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductEFRepo( AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _productDbSet = _context.Set<Product>();
    }

    public async  Task Create(ProductCreate productCreate)
    {
        var product = _mapper.Map<Product>(productCreate);
        await _productDbSet.AddAsync(product);
        await _context.SaveChangesAsync();
        productCreate.Id = product.Id;
    }

    public async Task<IEnumerable<Product>> List()
    {
        return _mapper.Map<IEnumerable<Product>>(await _productDbSet.ToListAsync());
    }

    public async Task Delete(int id)
    {
        this._productDbSet.Remove(new Product { Id = id });
        await _context.SaveChangesAsync();
    }

    public async Task Update( ProductUpdate product)
    {
        this._productDbSet.Update(_mapper.Map<Product>(product));
        await _context.SaveChangesAsync();
    }


    public async Task<Product?> Get(int id)
    {
        var product =  await this._productDbSet.FindAsync(id);
        return product;
    }
}