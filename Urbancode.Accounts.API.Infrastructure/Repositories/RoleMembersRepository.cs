using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class RoleMembersRepository : IRoleMembersRepository
{
    public async Task<IList<User>> GetRoleMembers(Guid roleId)
    {
        throw new NotImplementedException();
    }

    public async Task AddRoleMember(Guid roleId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveRoleMember(Guid roleId, Guid userId)
    {
        throw new NotImplementedException();
    }
}