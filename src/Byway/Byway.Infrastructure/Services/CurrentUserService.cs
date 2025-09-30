using Byway.Application.Common.Interfaces;
using Byway.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace Byway.Infrastructure.Services
{
    public class CurrentUserService(IHttpContextAccessor httpAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpAccessor = httpAccessor;
        public CurrentUser GetCurrentUser()
        {
            var user = _httpAccessor.HttpContext?.User;
            return new()
            {
                UserId = Guid.TryParse(user?.FindFirst("sub")?.Value, out var guid)
                    ? guid
                    : Guid.Empty,

                Role = user?.FindFirst("role")?.Value
            };

        }
    }
}
