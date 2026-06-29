using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PedidoApi.API.Controllers;

public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Email != "admin@gmail.com" || request.Password != "123")
            return Unauthorized("Credenciais inválidas.");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("K8xN4qP7mT2vR9cY5jL3wZ6uH1sD8eFa"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "PedidoApi",
            audience: "PedidoApi",
            claims: new[] { new Claim(ClaimTypes.Name, request.Email) },
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    public record LoginRequest(string Email, string Password);
}