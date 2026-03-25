using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class UserRolesService
{
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IUsersRepository _usersRepository;
    
    public UserRolesService(IUserRolesRepository userRolesRepository, IUsersRepository usersRepository)
    {
        _userRolesRepository = userRolesRepository;
        _usersRepository = usersRepository;
    }

    public async Task<Result<IList<Role>>> GetUserRoles(Guid id)
    {
        var user = await _usersRepository.GetUser(id);
        if (user == null) return CommonErrors.UserNotFoundError(id);
        
        var roles = await _userRolesRepository.GetUserRoles(id);
        return new(roles);
    }
}