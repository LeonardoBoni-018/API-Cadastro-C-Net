using MediatR;

namespace PedidoApi.Application.Queries;

public record GetUserByIdQuery(int Id) : IRequest<User?>;