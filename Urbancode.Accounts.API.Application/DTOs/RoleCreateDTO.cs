namespace Urbancode.Accounts.API.Logic.DTOs;

public record RoleCreateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}