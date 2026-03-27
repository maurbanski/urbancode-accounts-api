using System.Text.RegularExpressions;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class UserNameValidator
{
    public static bool ValidateUserName(string name)
    {
        if (name.Length < 2) return false;
        if (name.Length > 50) return false;
        if (Regex.IsMatch(name, "[<>\" \\\\;,/]")) return false;
        
        return true;
    }
}