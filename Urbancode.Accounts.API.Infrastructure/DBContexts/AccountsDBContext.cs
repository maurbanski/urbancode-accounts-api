using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Urbancode.Accounts.API.Infrastructure.DBContexts;

public class AccountsDBContext : IAccountsDBContext
{
    private readonly string _connectionString;

    public AccountsDBContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Accounts");
    }

    public IDbConnection Connection => new NpgsqlConnection(_connectionString);
}