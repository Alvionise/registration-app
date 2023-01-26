using System.Net.Http.Json;
using DomainService.ValueObjects.Email;
using DomainService.ValueObjects.Password;
using DomainService.WebApi.Commands.User.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DomainService.Integration.Tests;

/// <summary>
/// Integration test for User Controller
/// </summary>
public class UserControllerTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("a@a.a", "pass2", "pass2", true)]
    [InlineData("a@a", "ps2", "ps2", true)]
    [InlineData("a234234@a324234.a", "pass1231232", "pass1231232", true)]
    [InlineData("axcvzxv@a.a", "zcvzxcvzcxv2333", "zcvzxcvzcxv2333", true)]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string login, string password, string confirm, bool isAgree)
    {
        // Arrange
        var user = new CreateUserRequest
        {
            Password = new Password(password),
            IsAgreeWorkForFood = isAgree,
            ConfirmPassword = new Password(confirm),
            Login = new Email(login)
        };

        var url = "/api/users";
        var content = JsonContent.Create(user);
        var client = _factory.CreateClient();

        // Act
        var response = await client.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());

        var responseGuid = response.Content.ReadAsStringAsync();
        Assert.Contains("userId", responseGuid.Result);
    }
}
