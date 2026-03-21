using Urbancode.Accounts.API.Domain;
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

    public async Task<IList<Role>> GetRoles()
    {
        return await _rolesRepository.GetRoles();
    }

    public async Task<Role> GetRole(Guid id)
    {
        var role = await _rolesRepository.GetRole(id);
        if (role == null) throw new ArgumentException($"Role with this Id not found (Id: {id})");

        return role;
    }
    
    public async Task<Role> GetRole(string name)
    {
        var role = await _rolesRepository.GetRole(name);
        if (role == null) throw new ArgumentException($"Role with this name not found (Name: {name})");

        return role;
    }

    public async Task<Guid> CreateRole(RoleCreateDTO dto)
    {
        var roleWithThisName = await GetRole(dto.Name);
        if (roleWithThisName != null) throw new ArgumentException($"Role with this name already exists (Name: {dto.Name})");

        var role = new Role
        {
            Name = dto.Name,
            Active = true,
            DateCreated = DateTime.UtcNow
        };

        var id = await _rolesRepository.CreateRole(role);
        return id;
    }

    public async Task UpdateRole(RoleUpdateDTO dto)
    {
        var existingRole = await GetRole(dto.Id);
        if (existingRole == null) throw new ArgumentException($"Role with this Id not found (Id: {dto.Id})");
        
        var roleWithThisName = await GetRole(dto.Name);
        if (roleWithThisName != null)
            throw new ArgumentException($"Role with this name already exists (Name: {dto.Name})");

        var role = new Role
        {
            Id = dto.Id,
            Name = dto.Name,
            Active = dto.Active
        };

        await _rolesRepository.UpdateRole(role);
    }

    public async Task DeleteRole(Guid id)
    {
        var existingRole = await GetRole(id);
        if (existingRole == null) throw new ArgumentException($"Role with this Id not found (Id: {id})");

        await _rolesRepository.DeleteRole(id);
    }

}