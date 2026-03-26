using System.Net.Mail;

namespace Urbancode.Accounts.API.Logic.Validators;

public static class EmailValidator
{
    public static bool ValidateEmail(string email)
    {
        try
        {
            MailAddress address = new MailAddress(email);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}