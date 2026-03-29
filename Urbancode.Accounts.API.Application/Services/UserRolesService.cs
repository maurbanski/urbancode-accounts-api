using Microsoft.Extensions.Logging;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class UserRolesService
{
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger<UserRolesService> _logger;
    
    public UserRolesService(IUserRolesRepository userRolesRepository, IUsersRepository usersRepository, ILogger<UserRolesService> logger)
    {
        _userRolesRepository = userRolesRepository;
        _usersRepository = usersRepository;
        _logger = logger;
    }

    public async Task<Result<IList<Role>>> GetUserRoles(Guid id)
    {
        var user = await _usersRepository.GetUser(id);
        if (user == null) return CommonErrors.UserNotFoundError(id);
        
        _logger.LogInformation($"Retrieving user roles (Id: {id})");
        var roles = await _userRolesRepository.GetUserRoles(id);
        return new(roles);
    }
}