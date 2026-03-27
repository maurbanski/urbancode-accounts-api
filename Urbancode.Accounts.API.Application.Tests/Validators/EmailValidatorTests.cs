using Urbancode.Accounts.API.Logic.Validators;

namespace Urbancode.Accounts.API.Application.Tests.Validators;

public class EmailValidatorTests
{
    [Fact]
    public void ValidateEmail_ReturnsTrue_WhenPassedValidEmail()
    {
        var emailAddresses = new List<string>
        {
            "a.b@abc.com",
            "a-g@gmail.com",
            "fkads@fkdj-fd.co.uk",
            "aaaa@urbancode.dev",
            "disposable.style.email.with+symbol@example.com",
            "user@subdomain.example.com",
            "other.email-with-hyphen@example.com"
        };

        foreach (var address in emailAddresses)
        {
            Assert.True(EmailValidator.ValidateEmail(address));
        }
    }
    
    [Fact]
    public void ValidateEmail_ReturnsFalse_WhenPassedInvalidEmail()
    {
        var emailAddresses = new List<string>
        {
            "",
            "abc.example.com",
            "abc@example",
            "abc..def@example.com",
            "#@%^%#$@#$@#.com",
            "Joe Smith <email@example.com>",
            "あいうえお@example.com",
            "email@-example.com",
            "email@111.222.333.44444",
            "plainaddress",
            ".email@example.com",
            "email@example@example.com"
        };

        foreach (var address in emailAddresses)
        {
            Assert.False(EmailValidator.ValidateEmail(address));
        }
    }
}