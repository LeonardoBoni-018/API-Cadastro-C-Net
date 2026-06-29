using MediatR;
using Microsoft.EntityFrameworkCore;
using PedidoApi.Infrastructure.Persistence;

namespace PedidoApi.Application.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly AppDbContext _context;

    public GetUserByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
    }
}