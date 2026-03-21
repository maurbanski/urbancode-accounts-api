namespace Urbancode.Accounts.API.Logic.DTOs;

public class UserCreateDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}