using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test_mvc.Config;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;

namespace test_mvc.Repositories.EF;

public class UserEFRepo : IUserRepository
{
    
    private readonly DbSet<User> _userDbSet;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserEFRepo( AppDbContext context, IMapper mapper)
    {
        _context = context;
        _userDbSet = _context.Set<User>();

        _mapper = mapper;
    }


    public async Task Create(UserCreate user)
    {
        await _userDbSet.AddAsync(_mapper.Map<User>(user));
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserList>> List()
    {
        return _mapper.Map<IEnumerable<UserList>>(await _userDbSet.ToListAsync());
    }

    public async Task Delete(int id)
    {
        _userDbSet.Remove(_mapper.Map<User>(id));
        await _context.SaveChangesAsync();
    }

    public async  Task<UserList?> GetById(int id)
    {
        return _mapper.Map<UserList>(await _userDbSet.FindAsync(new
        {
            Id = id
        }));
        
    }

    public async Task<User?> GetByUserName(string userName)
    {
        return await _userDbSet.Where(u => u.UserName == userName).FirstOrDefaultAsync();
    }
}