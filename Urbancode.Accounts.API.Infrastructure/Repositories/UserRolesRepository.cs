using Dapper;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Infrastructure.DBContexts;
using Urbancode.Accounts.API.Infrastructure.Entities;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class UserRolesRepository : IUserRolesRepository
{
    private readonly IAccountsDBContext _accountsDBContext;
    
    public UserRolesRepository(IAccountsDBContext accountsDbContext)
    {
        _accountsDBContext = accountsDbContext;
    }
    
    public async Task<IList<Role>> GetUserRoles(Guid id)
    {
        var query = "SELECT * FROM roles r INNER JOIN role_membership rm ON rm.user_id = @id AND rm.role_id = r.id";

        using (var connection = _accountsDBContext.Connection)
        {
            var entities = await connection.QueryAsync<RoleEntity>(query, new {id});
            return entities.Select(x => x.ToRole()).ToList();
        }
    }
}