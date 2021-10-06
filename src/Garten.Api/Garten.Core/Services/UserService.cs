using AutoMapper;
using AutoMapper.QueryableExtensions;
using Garten.Core.Models.Filter;
using Garten.Core.Models.User;
using Garten.Core.Services.Interfaces;
using Garten.Database.Entities;
using Garten.Database.Repositories.Interfaces;
using Garten.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICryptoHelper _cryptoHelper;

        public UserService(IUserRepository userRepository, IMapper mapper, ICryptoHelper cryptoHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cryptoHelper = cryptoHelper;
        }

        public async Task<UserViewDto> CreateUserAsync(UserEditDto user, Guid adminId)
        {
            var newUser = await _userRepository.Create(_mapper.Map<User>(user), adminId);

            newUser.Password = _cryptoHelper.HashPassword(user.Password);

            return _mapper.Map<UserViewDto>(newUser);
        }

        public async Task<UserViewDto> EditUserAsync(Guid id, UserEditDto user, Guid adminId)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException();

            if (!string.IsNullOrWhiteSpace(user.FirstName))
                existingUser.FirstName = user.FirstName;
            if (!string.IsNullOrWhiteSpace(user.LastName))
                existingUser.LastName = user.LastName;
            if (!string.IsNullOrWhiteSpace(user.Patronymic))
                existingUser.Patronymic = user.Patronymic;
            if (user.Phone.HasValue)
                existingUser.Phone = user.Phone.Value;
            if (user.Roles?.Any() == true)
                existingUser.Roles = user.Roles.ToArray();

            return _mapper.Map<UserViewDto>(await _userRepository.Update(existingUser));
        }

        public async Task SetUserPasswordAsync(Guid id, SetPasswordRequestDto request)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException();

            existingUser.Password = _cryptoHelper.HashPassword(request.Password);

            await _userRepository.Update(existingUser);
        }

        public async Task<IEnumerable<UserViewDto>> ListUsersAsync(SortParamsDto sort)
        {
            var result = _userRepository
                .List()
                .ProjectTo<UserViewDto>(_mapper.ConfigurationProvider);

            if (sort.SortColumn == "LastName")
                result = sort.SortDesc
                    ? result
                        .OrderByDescending(p => p.LastName)
                        .ThenByDescending(p => p.FirstName)
                        .ThenByDescending(p => p.Patronymic)
                    : result
                        .OrderBy(p => p.LastName)
                        .ThenBy(p => p.FirstName)
                        .ThenBy(p => p.Patronymic);
            else
                result = result.OrderByDescending(p => p.DateCreated);

            if (sort.PageNumber > 0)
                result = result
                    .Skip(sort.PageNumber * sort.PageSize)
                    .Take(sort.PageSize);

            return await result.ToListAsync();
        }
    }
}
