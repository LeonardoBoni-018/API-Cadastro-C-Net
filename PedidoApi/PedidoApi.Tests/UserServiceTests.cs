using FluentAssertions;
using Moq;
using PedidoApi.Application.Services;
using PedidoApi.Domain.Repositories;

namespace PedidoApi.Tests;

public class UserServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldReturnUser()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(r => r.SaveAsync(It.IsAny<User>()))
            .ReturnsAsync((User u) => u);

        var service = new UserService(repoMock.Object);
        var result = await service.CreateAsync("João", "joao@email.com");

        result.Should().NotBeNull();
        result.Name.Should().Be("João");
        result.Email.Should().Be("joao@email.com");
    }
}