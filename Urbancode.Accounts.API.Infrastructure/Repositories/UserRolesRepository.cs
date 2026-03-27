using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class UserRolesRepository : IUserRolesRepository
{
    public async Task<IList<Role>> GetUserRoles(Guid id)
    {
        throw new NotImplementedException();
    }
}