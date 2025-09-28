using Byway.Application.Common;
using Byway.Application.DTOs.User;

namespace Byway.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<string>> RegisterAsync(CreateUserDto dto);
        Task<Result<string>> LoginAsync(LoginDto dto);
    }
}
