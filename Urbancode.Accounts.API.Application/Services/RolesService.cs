using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Interfaces;
using Urbancode.Accounts.API.Logic.Validators;

namespace Urbancode.Accounts.API.Logic.Services;

public class RolesService
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IRoleMembersRepository _roleMembersRepository;
    
    public RolesService(IRolesRepository rolesRepository, IRoleMembersRepository roleMembersRepository)
    {
        _rolesRepository = rolesRepository;
        _roleMembersRepository = roleMembersRepository;
    }

    public async Task<Result<IList<Role>>> GetRoles()
    {
        var roles = await _rolesRepository.GetRoles();
        return new(roles);
    }

    public async Task<Result<Role>> GetRole(Guid id)
    {
        var role = await _rolesRepository.GetRole(id);
        if (role == null) return CommonErrors.RoleNotFoundError(id);

        return role;
    }
    
    public async Task<Result<Role>> GetRole(string name)
    {
        if (!RoleNameValidator.ValidateRoleName(name)) return CommonErrors.InvalidRoleNameError(name);
        
        var role = await _rolesRepository.GetRole(name);
        if (role == null) return CommonErrors.RoleNotFoundError(name);

        return role;
    }

    public async Task<Result<Guid>> CreateRole(RoleCreateDTO dto)
    {
        if (!RoleNameValidator.ValidateRoleName(dto.Name)) return CommonErrors.InvalidRoleNameError(dto.Name);
        if (!(await CheckRoleNameAvailable(dto.Name))) return CommonErrors.RoleAlreadyExistsError(dto.Name);

        var role = new Role
        {
            Name = dto.Name,
            Active = true,
            DateCreated = DateTime.UtcNow
        };

        var id = await _rolesRepository.CreateRole(role);
        return id;
    }

    public async Task<Result> UpdateRole(RoleUpdateDTO dto)
    {
        if (!RoleNameValidator.ValidateRoleName(dto.Name)) return CommonErrors.InvalidRoleNameError(dto.Name);
        
        var existingRole = await _rolesRepository.GetRole(dto.Id);
        if (existingRole == null) return CommonErrors.RoleNotFoundError(dto.Id);
        if (dto.Name != existingRole.Value.Name && !(await CheckRoleNameAvailable(dto.Name))) return CommonErrors.RoleAlreadyExistsError(dto.Name);

        var role = new Role
        {
            Id = dto.Id,
            Name = dto.Name,
            Active = dto.Active
        };

        await _rolesRepository.UpdateRole(role);
        return Result.Success();
    }

    public async Task<Result> DeleteRole(Guid id)
    {
        var existingRole = await _rolesRepository.GetRole(id);
        if (existingRole == null) return CommonErrors.RoleNotFoundError(id);

        var roleMembers = await _roleMembersRepository.GetRoleMembers(id);
        foreach (var member in roleMembers)
        {
            await _roleMembersRepository.RemoveRoleMember(id, member.Id);
        }

        await _rolesRepository.DeleteRole(id);
        return Result.Success();
    }

    private async Task<bool> CheckRoleNameAvailable(string name)
    {
        var roleWithThisName = await _rolesRepository.GetRole(name);
        return roleWithThisName == null;
    }

}