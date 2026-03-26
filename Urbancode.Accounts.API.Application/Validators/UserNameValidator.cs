using System.Text.RegularExpressions;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class UserNameValidator
{
    private static IEnumerable<char> _invalidChars = new[] { '<', '>', '"', ' ', '/', '\\', ';' };
    private static Regex _invalidCharsRegex => new Regex(String.Join("|", _invalidChars));
    
    public static bool ValidateUserName(string name)
    {
        if (name.Length < 2) return false;
        if (name.Length > 50) return false;
        if (_invalidCharsRegex.IsMatch(name)) return false;
        
        return true;
    }
}