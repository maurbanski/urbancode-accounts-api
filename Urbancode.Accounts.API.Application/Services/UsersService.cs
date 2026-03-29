using Microsoft.Extensions.Logging;
using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Interfaces;
using Urbancode.Accounts.API.Logic.Validators;

namespace Urbancode.Accounts.API.Logic.Services;

public class UsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IRoleMembersRepository _roleMembersRepository;
    private readonly ILogger<UsersService> _logger;
    
    public UsersService(IUsersRepository usersRepository, IUserRolesRepository userRolesRepository, 
        IRoleMembersRepository roleMembersRepository, ILogger<UsersService> logger)
    {
        _usersRepository = usersRepository;
        _userRolesRepository = userRolesRepository;
        _roleMembersRepository = roleMembersRepository;
        _logger = logger;
    }

    public async Task<Result<IList<User>>> GetUsers()
    {
        _logger.LogInformation("Retrieving users");
        var users = await _usersRepository.GetUsers();
        return new(users);
    }

    public async Task<Result<User>> GetUser(Guid id)
    {
        _logger.LogInformation($"Retrieving user (Id: {id})");
        var user = await _usersRepository.GetUser(id);
        if (user == null) return CommonErrors.UserNotFoundError(id);

        return user;
    }

    public async Task<Result<User>> GetUser(string email)
    {
        if (!EmailValidator.ValidateEmail(email)) return CommonErrors.InvalidEmailError(email);
        
        _logger.LogInformation($"Retrieving user (Email: {email})");
        var user = await _usersRepository.GetUser(email);
        if (user == null) return CommonErrors.UserNotFoundError(email);

        return user;
    }

    public async Task<Result> CreateUser(UserCreateDTO dto)
    {
        if (!EmailValidator.ValidateEmail(dto.Email)) return CommonErrors.InvalidEmailError(dto.Email);
        if (!UserNameValidator.ValidateUserName(dto.Name)) return CommonErrors.InvalidUserNameError(dto.Name);

        if (!(await CheckIdAvailable(dto.Id))) return CommonErrors.UserAlreadyExistsError(dto.Id);
        if (!(await CheckEmailAvailable(dto.Email))) return CommonErrors.UserAlreadyExistsError(dto.Email);
        
        var user = new User
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Active = true,
            DateCreated = DateTime.UtcNow
        };

        _logger.LogInformation($"Creating user (Id: {user.Id}, Name: {user.Name}, Email: {user.Email})");
        await _usersRepository.CreateUser(user);
        return Result.Success();
    }

    public async Task<Result> UpdateUser(UserUpdateDTO dto)
    {
        if (!EmailValidator.ValidateEmail(dto.Email)) return CommonErrors.InvalidEmailError(dto.Email);
        if (!UserNameValidator.ValidateUserName(dto.Name)) return CommonErrors.InvalidUserNameError(dto.Name);

        var existingUser = await _usersRepository.GetUser(dto.Id);
        if (existingUser == null) return CommonErrors.UserNotFoundError(dto.Id);
        if (dto.Email != existingUser.Value.Email && !(await CheckEmailAvailable(dto.Email))) return CommonErrors.UserAlreadyExistsError(dto.Email);
        
        var user = new User
        {
            Id = dto.Id,
            Email = dto.Email,
            Name = dto.Name,
            Active = dto.Active
        };

        _logger.LogInformation(
            $"Updating user (Id: {user.Id}, Name: {existingUser.Value.Name} -> {user.Name}, Email: {existingUser.Value.Email} -> {user.Email}, Active: {existingUser.Value.Active} -> {user.Active})");
        await _usersRepository.UpdateUser(user);
        return Result.Success();
    }

    public async Task<Result> DeleteUser(Guid id)
    {
        var existingUser = await _usersRepository.GetUser(id);
        if (existingUser == null) return CommonErrors.UserNotFoundError(id);

        _logger.LogInformation($"Removing user roles before deletion (Id: {id})");
        var userRoles = await _userRolesRepository.GetUserRoles(id);
        foreach (var role in userRoles)
        {
            _logger.LogInformation($"Removing user role (User Id: {id}, Role Id: {role.Id})");
            await _roleMembersRepository.RemoveRoleMember(role.Id, id);
        }

        _logger.LogInformation($"Retrieving user (Id: {id})");
        await _usersRepository.DeleteUser(id);
        return Result.Success();
    }

    private async Task<bool> CheckEmailAvailable(string email)
    {
        var userWithThisEmail = await _usersRepository.GetUser(email);
        return (userWithThisEmail == null);
    }

    private async Task<bool> CheckIdAvailable(Guid id)
    {
        var userWithThisId = await _usersRepository.GetUser(id);
        return (userWithThisId == null);
    }
}