using Urbancode.Accounts.API.Logic.Validators;

namespace Urbancode.Accounts.API.Application.Tests.Validators;

public class UserNameValidatorTests
{
    [Fact]
    public void ValidateUserName_ReturnsTrue_WhenPassedValidName()
    {
        var names = new List<string>
        {
            "abc",
            "abc123",
            "abc-123",
            "-abc",
            "$abc-123_",
            "abc.def"
        };
        
        foreach (var name in names)
        {
            Assert.True(UserNameValidator.ValidateUserName(name));
        }
    }
    
    [Fact]
    public void ValidateUserName_ReturnsFalse_WhenPassedInvalidName()
    {
        var names = new List<string>
        {
            "<script>Alert('A')</script>",
            "abc\\def",
            ";DROP TABLE *",
            "rdhacmvfrgywklnemrhuktqqffitqiiaphheeqfkrzioadqquavzxpkedwwdmfhlbqrdqwwphwdhmadfkuxwqgyvkwqfzkldupavdjnsfuulprgbyqlofeuq",
            "ab,c",
            "a",
            "abc\"def"
        };
        
        foreach (var name in names)
        {
            Assert.False(UserNameValidator.ValidateUserName(name));
        }
    }
}