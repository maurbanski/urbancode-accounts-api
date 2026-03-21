using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Logic.Interfaces;

public interface IRolesRepository
{
    Task<IList<Role>> GetRoles();
    Task<Role> GetRole(Guid id);
    Task<Role> GetRole(string name);
    Task<Guid> CreateRole(Role role);
    Task UpdateRole(Role role);
    Task DeleteRole(Guid id);
}