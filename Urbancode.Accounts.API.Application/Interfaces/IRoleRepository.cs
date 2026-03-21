using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Logic.Interfaces;

public interface IRoleRepository
{
    Task<IList<Role>> GetUsers();
    Task<Role> GetUser(Guid id);
    Task<Role> GetUser(string email);
    Task CreateUser(Role role);
    Task UpdateUser(Role role);
    Task DeleteUser(Guid id);
}