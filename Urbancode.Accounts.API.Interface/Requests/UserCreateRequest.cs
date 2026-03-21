namespace Urbancode.Accounts.API.Interface.Requests;

public class UserCreateRequest
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string? Name { get; set; }
}