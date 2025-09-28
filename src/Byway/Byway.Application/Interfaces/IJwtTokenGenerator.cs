using Byway.Domain.Entities;

namespace Byway.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AppUser user, IList<string> roles);

    }
}
