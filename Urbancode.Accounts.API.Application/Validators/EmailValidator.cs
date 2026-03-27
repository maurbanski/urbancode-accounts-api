using System.Text.RegularExpressions;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class EmailValidator
{
    public static bool ValidateEmail(string email)
    {
        if (Regex.IsMatch(email, @"^[._%-\+]+.*")) return false;
        if (Regex.IsMatch(email, @"^.*[.-]+@.*$")) return false;
        if (Regex.IsMatch(email, @"^.*@+[.-].*$")) return false;
        if (Regex.IsMatch(email, @".*[._%-\+]{2}.*")) return false;

        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }
}