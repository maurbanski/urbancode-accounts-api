using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Logic.Interfaces;

public interface IUsersRepository
{
    Task<IList<User>> GetUsers();
    Task<User> GetUser(Guid id);
    Task<User> GetUser(string email);
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(Guid id);
}