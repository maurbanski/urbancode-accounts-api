using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class RoleMembersService
{
    private readonly IRoleMembersRepository _roleMembersRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly 
    
    public RoleMembersService(IRoleMembersRepository roleMembersRepository, IRolesRepository rolesRepository)
    {
        _roleMembersRepository = roleMembersRepository;
        _rolesRepository = rolesRepository;
    }

    public async Task<IList<User>> GetRoleMembers(Guid id)
    {
        var role = await _rolesRepository.GetRole(id);
        if (role == null) throw new ArgumentException($"Role with this Id not found (Id: {id})");

        return await _roleMembersRepository.GetRoleMembers(id);
    }

    public async Task AddRoleMember(Guid roleId, Guid userId)
    {
        var role = await _rolesRepository.GetRole(roleId);
        if (role == null) throw new ArgumentException($"Role with this Id not found (Id: {roleId})");
        
        var user = await _(id);
        if (user == null) throw new ArgumentException($"User with this Id not found (Id: {id})");
        
        
    }
}