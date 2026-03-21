using Urbancode.Accounts.API.Domain;
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

    public async Task<IList<Role>> GetUserRoles(Guid id)
    {
        var user = await _usersRepository.GetUser(id);
        if (user == null) throw new ArgumentException($"User with this Id not found (Id: {id})");
        
        return await _userRolesRepository.GetUserRoles(id);
    }
}