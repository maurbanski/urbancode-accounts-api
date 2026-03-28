using Dapper;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Infrastructure.DBContexts;
using Urbancode.Accounts.API.Infrastructure.Entities;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class RolesRepository : IRolesRepository
{
    private readonly IAccountsDBContext _accountsDBContext;
    
    public RolesRepository(IAccountsDBContext accountsDbContext)
    {
        _accountsDBContext = accountsDbContext;
    }
    
    public async Task<IList<Role>> GetRoles()
    {
        var query = "SELECT * FROM roles";

        using (var connection = _accountsDBContext.Connection)
        {
            var entities = await connection.QueryAsync<RoleEntity>(query);
            return entities.Select(x => x.ToRole()).ToList();
        }
    }

    public async Task<Role?> GetRole(Guid id)
    {
        var query = "SELECT * FROM roles WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            var entity = await connection.QuerySingleOrDefaultAsync<RoleEntity>(query, new {id});
            return (entity == null) ? null : entity.ToRole();
        }
    }

    public async Task<Role?> GetRole(string name)
    {
        var query = "SELECT * FROM roles WHERE name = @name";

        using (var connection = _accountsDBContext.Connection)
        {
            var entity = await connection.QuerySingleOrDefaultAsync<RoleEntity>(query, new {name});
            return (entity == null) ? null : entity.ToRole();
        }
    }

    public async Task<Guid> CreateRole(Role role)
    {
        var query = "INSERT INTO roles (name, active, date_created) VALUES (@name, @active, @date_created) RETURNING id";

        using (var connection = _accountsDBContext.Connection)
        {
            var roleId = await connection.QuerySingleAsync<Guid>(query, new RoleEntity(role));
            return roleId;
        }
    }

    public async Task UpdateRole(Role role)
    {
        var query = "UPDATE roles SET name = @name, active = @active WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new RoleEntity(role));
        }
    }

    public async Task DeleteRole(Guid id)
    {
        var query = "DELETE FROM roles WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new {id});
        }
    }
}