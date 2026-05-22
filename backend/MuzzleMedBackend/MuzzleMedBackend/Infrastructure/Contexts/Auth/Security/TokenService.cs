using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;

namespace MuzzleMedBackend.Infrastructure.Security;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(UserAuthContext user)
    {
        var _secretKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var handler = new JwtSecurityTokenHandler();
         
        var credentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), 
            SecurityAlgorithms.HmacSha256Signature);

        static ClaimsIdentity GenerateClaims(UserAuthContext user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            
            ci.AddClaim(new Claim(ClaimTypes.Email, user.EmailAuthContext.Address));
            
            return ci;
        }
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            
            Subject = GenerateClaims(user),
            SigningCredentials = credentials

        };
        
        
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);


    }
}