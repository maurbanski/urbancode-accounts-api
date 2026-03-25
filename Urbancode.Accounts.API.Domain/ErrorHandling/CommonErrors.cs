namespace Urbancode.Accounts.API.Domain.ErrorHandling;

public static class CommonErrors
{
    public static Error RoleNotFoundError(Guid id) =>
        new Error(ErrorType.NotFound,
            "Role not found",
            $"Role with this Id not found (Id: {id})");
    
    public static Error RoleNotFoundError(string name) => 
        new Error(ErrorType.NotFound,
        "Role not found",
        $"Role with this name not found (Name: {name})");
    
    public static Error RoleAlreadyExistsError(string name) => 
        new Error(ErrorType.Conflict,
            "Role with this name already exists",
            $"Role with this name already exists (Name: {name})");

    public static Error UserNotFoundError(Guid id) =>
        new Error(ErrorType.NotFound,
            "User not found",
            $"User with this Id not found (Id: {id})");

    public static Error UserNotFoundError(string email) =>
        new Error(ErrorType.NotFound,
            "User not found",
            $"User with this email not found (Email: {email})");

    public static Error UserAlreadyExistsError(string email) =>
        new Error(ErrorType.Conflict,
            "User already exists",
            $"User with this email already exists (Email: {email})");
}