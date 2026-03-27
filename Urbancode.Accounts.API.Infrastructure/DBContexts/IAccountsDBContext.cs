using System.Data;

namespace Urbancode.Accounts.API.Infrastructure.DBContexts;

public interface IAccountsDBContext
{
    IDbConnection Connection { get; }
}