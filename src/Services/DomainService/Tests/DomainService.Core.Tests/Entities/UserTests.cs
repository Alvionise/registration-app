using DomainService.Core.Domain.Entities;

namespace DomainService.Core.Tests.Entities;

/// <summary>
/// Test for User
/// </summary>
public class UserTests
{
    private readonly IFixture _fixture;

    public UserTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void CreateUser_WithData_ShouldBeCreated()
    {
        var user = _fixture.Create<User>();
        Assert.NotNull(user);
        Assert.Null(user.Province);
    }


    [Fact]
    public void SetProvince_WithData_ShouldBeSetted()
    {
        var user = _fixture.Create<User>();
        Assert.Null(user.Province);

        var province = _fixture.Build<Province>()
            .With(x => x.Name, "TEST PROVINCE NAME")
            .Without(x => x.Country)
            .Create();

        user.SetProvince(province);
        Assert.NotNull(user.Province);
    }
}
