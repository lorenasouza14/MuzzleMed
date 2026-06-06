using System.Security.Claims;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Services;

public class GetUserIdService : IGetUserIdService
{
    private readonly IHttpContextAccessor _accessor;

    public GetUserIdService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public Guid GetUserId()
    {
        var value =  _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(value) || !Guid.TryParse(value, out Guid userId))
        {
            throw new UnauthorizedAccessException("Usuário não autenticado ou ID de usuário inválido/inexistente no token.");
        }
        
        return userId;
    }
}