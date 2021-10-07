using Garten.Core.Models.Filter;
using Garten.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garten.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewDto> CreateUserAsync(UserEditDto user, Guid adminId);
        Task<UserViewDto> EditUserAsync(Guid id, UserEditDto user, Guid adminId);
        Task SetUserPasswordAsync(Guid userId, SetPasswordRequestDto request);
        Task<IEnumerable<UserViewDto>> ListUsersAsync(SortParamsDto sort);
        Task<UserViewDto> GetUserByIdAsync(Guid id);
    }
}
