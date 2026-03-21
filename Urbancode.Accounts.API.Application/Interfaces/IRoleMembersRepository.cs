using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Logic.Interfaces;

public interface IRoleMembersRepository
{
    Task<IList<User>> GetRoleMembers(Guid roleId);
    Task AddRoleMember(Guid roleId, Guid userId);
    Task RemoveRoleMember(Guid roleId, Guid userId);
}