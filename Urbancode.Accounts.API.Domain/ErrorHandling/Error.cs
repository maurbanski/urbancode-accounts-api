namespace Urbancode.Accounts.API.Domain.ErrorHandling;

public record Error(ErrorType Type, string MessageShort, string MessageLong);