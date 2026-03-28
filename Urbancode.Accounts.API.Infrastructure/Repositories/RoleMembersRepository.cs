using Dapper;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Infrastructure.DBContexts;
using Urbancode.Accounts.API.Infrastructure.Entities;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class RoleMembersRepository : IRoleMembersRepository
{
    private readonly IAccountsDBContext _accountsDBContext;
    
    public RoleMembersRepository(IAccountsDBContext accountsDbContext)
    {
        _accountsDBContext = accountsDbContext;
    }
    
    public async Task<IList<User>> GetRoleMembers(Guid roleId)
    {
        var query = "SELECT * FROM users u INNER JOIN role_membership rm ON rm.role_id = @roleId AND rm.user_id = u.id";

        using (var connection = _accountsDBContext.Connection)
        {
            var entities = await connection.QueryAsync<UserEntity>(query, new { role_id = roleId});
            return entities.Select(x => x.ToUser()).ToList();
        }    
    }

    public async Task AddRoleMember(Guid roleId, Guid userId)
    {
        var query = "INSERT INTO role_membership (role_id, user_id) VALUES (@role_id, @user_id)";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new { role_id = roleId, user_id = userId});
        }    
    }

    public async Task RemoveRoleMember(Guid roleId, Guid userId)
    {
        var query = "DELETE FROM role_membership WHERE role_id = @role_id AND user_id = @user_id";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new { role_id = roleId, user_id = userId});
        }   
    }
}