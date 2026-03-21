using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Logic.Interfaces;

public interface IUserRolesRepository
{
    Task<IList<Role>> GetUserRoles(Guid id);
}