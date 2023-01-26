using DomainService.ValueObjects.Password;

namespace DomainService.Core.Tests.ValuesObjectTests;
public class PasswordTests
{
    private readonly PasswordValidator _validator = new();

    [Theory]
    [InlineData("123qwe")]
    [InlineData("1w")]
    [InlineData("aaaaaaaassssssssssdddddddddd3333333")]
    [InlineData("zxcxvcx23")]
    public void CreatePasswordValueObject_WithValidValues_ShouldBeOk(string value)
    {
        var password = new Password(value);
        var res = _validator.Validate(password);
        Assert.Empty(res.Errors);
    }


    [Theory]
    [InlineData("sdf")]
    [InlineData("123")]
    [InlineData("////fff")]
    [InlineData("xcvXXX_")]
    public void CreateEmailValueObject_WithNonValidValues_ShouldBeContainError(string value)
    {
        var password = new Password(value);
        var res = _validator.Validate(password);
        Assert.NotEmpty(res.Errors);
    }
}
