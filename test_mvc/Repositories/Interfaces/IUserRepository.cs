using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Repositories.Interfaces;

public interface IUserRepository
{
    Task Create(UserCreate product);
    Task<IEnumerable<UserList>> List();
    Task Delete(int id);
    Task<UserList?> GetById(int id);
    Task<User?> GetByUserName(string userName);
}