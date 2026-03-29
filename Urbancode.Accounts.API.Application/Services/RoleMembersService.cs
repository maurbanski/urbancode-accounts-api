using Microsoft.Extensions.Logging;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class RoleMembersService
{
    private readonly IRoleMembersRepository _roleMembersRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger<RoleMembersService> _logger;
    
    public RoleMembersService(IRoleMembersRepository roleMembersRepository, IRolesRepository rolesRepository, IUsersRepository usersRepository, ILogger<RoleMembersService> logger)
    {
        _roleMembersRepository = roleMembersRepository;
        _rolesRepository = rolesRepository;
        _usersRepository = usersRepository;
        _logger = logger;
    }

    public async Task<Result<IList<User>>> GetRoleMembers(Guid id)
    {
        var role = await _rolesRepository.GetRole(id);
        if (role == null) return CommonErrors.RoleNotFoundError(id);

        _logger.LogInformation($"Retrieving role members (Id: {id})");
        var roleMembers = await _roleMembersRepository.GetRoleMembers(id);
        return new(roleMembers);
    }

    public async Task<Result> AddRoleMember(Guid roleId, Guid userId)
    {
        var role = await _rolesRepository.GetRole(roleId);
        if (role == null) return CommonErrors.RoleNotFoundError(roleId);
            
        var user = await _usersRepository.GetUser(userId);
        if (user == null) return CommonErrors.UserNotFoundError(userId);
            
        _logger.LogInformation($"Adding role member (Role Id: {roleId}, UserId: {userId})");
        await _roleMembersRepository.AddRoleMember(roleId, userId);
        return Result.Success();
    }

    public async Task<Result> RemoveRoleMember(Guid roleId, Guid userId)
    {
        var role = await _rolesRepository.GetRole(roleId);
        if (role == null) return CommonErrors.RoleNotFoundError(roleId);   
            
        var user = await _usersRepository.GetUser(userId);
        if (user == null) return CommonErrors.UserNotFoundError(userId);

        _logger.LogInformation($"Removing role member (Role Id: {roleId}, UserId: {userId})");
        await _roleMembersRepository.RemoveRoleMember(roleId, userId);
        return Result.Success();
    }
}