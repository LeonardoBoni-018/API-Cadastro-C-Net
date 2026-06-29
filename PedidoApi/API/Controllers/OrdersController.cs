using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoApi.Infrastructure.Persistence;

namespace PedidoApi.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _context.Orders
            .Include(o => o.User)
            .OrderByDescending(o => o.Id)
            .ToListAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user is null) return NotFound("Usuário não encontrado");

        var order = new Order { Value = request.Value, UserId = request.UserId };
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = order.Id }, order);
    }

    public record CreateOrderRequest(decimal Value, int UserId);
}