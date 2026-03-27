using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class RolesRepository : IRolesRepository
{
    public async Task<IList<Role>> GetRoles()
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetRole(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetRole(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRole(Guid id)
    {
        throw new NotImplementedException();
    }
}