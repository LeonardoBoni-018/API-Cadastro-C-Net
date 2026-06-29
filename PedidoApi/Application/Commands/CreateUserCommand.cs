using MediatR;

namespace PedidoApi.Application.Commands;
public record CreateUserCommand(string Name, string Email) : IRequest<User>;