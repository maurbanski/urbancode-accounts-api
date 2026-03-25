using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class RolesService
{
    private readonly IRolesRepository _rolesRepository;
    
    public RolesService(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
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
        var role = await _rolesRepository.GetRole(name);
        if (role == null) return CommonErrors.RoleNotFoundError(name);

        return role;
    }

    public async Task<Result<Guid>> CreateRole(RoleCreateDTO dto)
    {
        var roleWithThisName = await _rolesRepository.GetRole(dto.Name);
        if (roleWithThisName != null) return CommonErrors.RoleAlreadyExistsError(dto.Name);

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
        var existingRole = await _rolesRepository.GetRole(dto.Id);
        if (existingRole == null) return CommonErrors.RoleNotFoundError(dto.Id);
        
        var roleWithThisName = await _rolesRepository.GetRole(dto.Name);
        if (roleWithThisName != null) return CommonErrors.RoleAlreadyExistsError(dto.Name);

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
        var existingRole = await GetRole(id);
        if (existingRole == null) return CommonErrors.RoleNotFoundError(id);

        await _rolesRepository.DeleteRole(id);
        return Result.Success();
    }

}