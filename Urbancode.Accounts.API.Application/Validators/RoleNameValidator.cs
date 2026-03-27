using System.Text.RegularExpressions;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class RoleNameValidator
{
    public static bool ValidateRoleName(string name)
    {
        if (name.Length < 3) return false;
        if (name.Length > 100) return false;
        if (Regex.IsMatch(name, "[<>\" \\\\;,]")) return false;
        
        return true;
    }
}