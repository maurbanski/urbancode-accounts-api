using System.Data;
using Npgsql;

namespace Urbancode.Accounts.API.Infrastructure.DBContexts;

public class AccountsDBContext : IAccountsDBContext
{
    private readonly string _connectionString;

    public AccountsDBContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Connection => new NpgsqlConnection(_connectionString);
}