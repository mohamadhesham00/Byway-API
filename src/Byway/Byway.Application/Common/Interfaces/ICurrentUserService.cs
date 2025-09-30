using Byway.Application.Common.Models;

namespace Byway.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public CurrentUser GetCurrentUser();

    }
}
