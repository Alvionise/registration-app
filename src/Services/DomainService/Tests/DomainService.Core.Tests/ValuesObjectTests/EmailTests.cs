using DomainService.ValueObjects.Email;

namespace DomainService.Core.Tests.ValuesObjectTests;

/// <summary>
/// Test for VO Email
/// </summary>
public class EmailTests
{
    private readonly EmailValidator _validator = new();

    [Theory]
    [InlineData("a@a.a")]
    [InlineData("ss@aaxss.ad")]
    [InlineData("aasd@aasd.acccx")]
    [InlineData("acvx@axcv.a")]
    public void CreateEmailValueObject_WithValidValues_ShouldBeOk(string value)
    {
        var emailVo = new Email(value);
        var res = _validator.Validate(emailVo);
        Assert.Empty(res.Errors);
    }


    [Theory]
    [InlineData("sdf")]
    [InlineData("123")]
    [InlineData("////*/@")]
    [InlineData("xcv13345")]
    public void CreateEmailValueObject_WithNonValidValues_ShouldBeContainError(string value)
    {
        var emailVo = new Email(value);
        var res = _validator.Validate(emailVo);
        Assert.NotEmpty(res.Errors);
    }
}
