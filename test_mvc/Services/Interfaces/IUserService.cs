using System.IdentityModel.Tokens.Jwt;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Services.Interfaces;

public interface IUserService
{
    Task<UserList> Authenticate(UserLogin userLogin);
    Task Register(UserCreate user);
    Task<IEnumerable<UserList>> ListUsers();
}