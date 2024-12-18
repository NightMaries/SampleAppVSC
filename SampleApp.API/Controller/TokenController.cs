using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleApp.API.Interfaces;

[ApiController]
[Route("/[controller]")]

public class TokenController : ControllerBase
{
    private readonly IConfiguration _config;

    public TokenController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public IActionResult GenerateToken()
    {
        var claims = new List<Claim> {new Claim(ClaimTypes.Name,"user")};
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]!));
  
        //Создание JWT токена

        var jwt = new JwtSecurityToken(
            // issuer: _config["Jwt:Isuuer"],
            // audience: _config["Jwt: Audience"],
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(365)),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
        
        return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));

    }

}