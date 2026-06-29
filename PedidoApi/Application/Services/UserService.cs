// using PedidoApi.Domain.Repositories;

namespace PedidoApi.Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(string name, string email)
    {
        var user = new User(name, email);
        return await _repository.SaveAsync(user);
    }
}