using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test_mvc.Config;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;

namespace test_mvc.Repositories.EF;

public class CategoryEFRepo :ICategoryRepository
{
    
    private readonly DbSet<Category> _productDbSet;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryEFRepo( AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _productDbSet = _context.Set<Category>();
    }

    public async  Task Create(CategoryCreate product)
    {
        await this._productDbSet.AddAsync( _mapper.Map<Category>(product) );
        await this._context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryList>> Category()
    {
       return _mapper.Map<IEnumerable<CategoryList>>( await this._productDbSet.ToListAsync());
    }

    public async Task Delete(int id)
    {
        this._productDbSet.Remove(new Category { Id = id });
        await _context.SaveChangesAsync();
    }

    public async  Task Update(CategoryUpdate product)
    {
         this._productDbSet.Update(_mapper.Map<Category>(product));
         await _context.SaveChangesAsync();
    }

    public async  Task<Category?> Get(int id)
    {
        return await this._productDbSet.FindAsync(id);        
    }
}