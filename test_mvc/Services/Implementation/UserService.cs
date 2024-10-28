using AutoMapper;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;
using test_mvc.Repositories.Interfaces;
using test_mvc.Services.Interfaces;

namespace test_mvc.Services.Implementation;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserList> Authenticate(UserLogin userLogin)
    {
        var u  = await _userRepository.GetByUserName(userLogin.UserName);
        if (u == null)
        {
            throw new Exception($"User {userLogin.UserName} not found");
        }

        if (u.Password != userLogin.Password)
        {
            throw new Exception($"User name or password did not match");
        }

        return _mapper.Map<UserList>(u);
    }

    public async Task Register(UserCreate user)
    {
        var u  = await _userRepository.GetByUserName(user.UserName);
        if (u != null)
        {
            throw new Exception($"User {user.UserName} already exists");
        }
        user.UserRole = UserRole.Customer;
        await _userRepository.Create(user);
    }

    public async Task<IEnumerable<UserList>> ListUsers()
    {
        return await _userRepository.List();
    }
}