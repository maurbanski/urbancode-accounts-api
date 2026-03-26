using System.Text.RegularExpressions;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class RoleNameValidator
{
    private static IEnumerable<char> _invalidChars = new[] { '<', '>', '"', ' ', '\\', ';', ',' };
    private static Regex _invalidCharsRegex => new Regex(String.Join("|", _invalidChars));
    
    public static bool ValidateRoleName(string name)
    {
        if (name.Length < 3) return false;
        if (name.Length > 100) return false;
        if (_invalidCharsRegex.IsMatch(name)) return false;
        
        return true;
    }
}