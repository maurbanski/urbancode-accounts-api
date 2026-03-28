using Dapper;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Infrastructure.DBContexts;
using Urbancode.Accounts.API.Infrastructure.Entities;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IAccountsDBContext _accountsDBContext;
    
    public UsersRepository(IAccountsDBContext accountsDbContext)
    {
        _accountsDBContext = accountsDbContext;
    }
    
    public async Task<IList<User>> GetUsers()
    {
        var query = "SELECT * FROM users";

        using (var connection = _accountsDBContext.Connection)
        {
            var entities = await connection.QueryAsync<UserEntity>(query);
            return entities.Select(x => x.ToUser()).ToList();
        }
    }
    
    public async Task<User?> GetUser(Guid id)
    {
        var query = "SELECT * FROM users WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            var entity = await connection.QuerySingleOrDefaultAsync(query, new {id});
            return entity == null ? null : ((UserEntity)entity).ToUser();
        }
    }
    
    public async Task<User?> GetUser(string email)
    {
        var query = "SELECT * FROM users WHERE email = @email";

        using (var connection = _accountsDBContext.Connection)
        {
            var entity = await connection.QuerySingleOrDefaultAsync(query, new {email});
            return entity == null ? null : ((UserEntity)entity).ToUser();
        }
    }
    
    public async Task CreateUser(User user)
    {
        var query = "INSERT INTO users (id, email, name, active, date_created) VALUES (@id, @email, @name, @active, @date_created)";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new UserEntity(user));
        }
    }
    
    public async Task UpdateUser(User user)
    {
        var query = "UPDATE users SET email = @email, name = @name, active = @active, date_created = @date_created WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new UserEntity(user));
        }
    }
    
    public async Task DeleteUser(Guid id)
    {
        var query = "DELETE FROM users WHERE id = @id";

        using (var connection = _accountsDBContext.Connection)
        {
            await connection.QueryAsync(query, new {id});
        }
    }
}