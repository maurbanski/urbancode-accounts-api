using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Infrastructure.DBContexts;
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
        throw new NotImplementedException();
    }
    
    public async Task<User?> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<User?> GetUser(string email)
    {
        throw new NotImplementedException();
    }
    
    public async Task CreateUser(User user)
    {
        throw new NotImplementedException();
    }
    
    public async Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }
}