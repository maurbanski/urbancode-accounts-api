namespace Urbancode.Accounts.API.Interface.Requests;

public class UserUpdateRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
}