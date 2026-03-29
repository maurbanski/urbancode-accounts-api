using Urbancode.Accounts.API.Infrastructure.DBContexts;
using Urbancode.Accounts.API.Infrastructure.Repositories;
using Urbancode.Accounts.API.Logic.Interfaces;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var accountsConnectionString = builder.Configuration.GetConnectionString("Accounts");
        builder.Services.AddScoped<IAccountsDBContext, AccountsDBContext>(provider => new AccountsDBContext(accountsConnectionString));

        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IRolesRepository, RolesRepository>();
        builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
        builder.Services.AddScoped<IRoleMembersRepository, RoleMembersRepository>();
    }

    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<UsersService>();
        builder.Services.AddScoped<RolesService>();
        builder.Services.AddScoped<UserRolesService>();
        builder.Services.AddScoped<RoleMembersService>();
    }
}