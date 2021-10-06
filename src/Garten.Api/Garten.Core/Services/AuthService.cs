using Garten.Common.Models.User;
using Garten.Core.Models.Login;
using Garten.Core.Services.Interfaces;
using Garten.Database.Entities;
using Garten.Database.Repositories.Interfaces;
using Garten.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly ICryptoHelper _cryptoHelper;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository, IAdminRepository adminRepository, IUserSessionRepository userSessionRepository,
            ICryptoHelper cryptoHelper, 
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userSessionRepository = userSessionRepository;
            _adminRepository = adminRepository;

            _cryptoHelper = cryptoHelper;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request)
        {
            var normalizedPhone = normalizePhone(request.Phone);
            var hashedPassword = _cryptoHelper.HashPassword(request.Password);

            var user = await _userRepository.GetByPhoneAsync(normalizedPhone);
            if(user == null 
                || user.Password != hashedPassword
                || !user.Roles.Any(role => LoginUserRoles.Contains(role)))
                throw new UnauthorizedAccessException();

            user.DateLastLogin = DateTime.UtcNow;
            await _userRepository.Update(user);

            var session = await _userSessionRepository.Create(new UserSession(), user.Id);

            var role = getHighestUserRole(user.Roles);
            return new LoginResponseDto
            {
                Token = _cryptoHelper.GenerateAuthToken(user.Id, session.Id, role, _configuration["Security:Secret"]),
                Role = role
            };

            throw new UnauthorizedAccessException();
        }

        public async Task<LoginResponseDto> LoginAdminAsync(LoginRequestDto request)
        {
            var normalizedPhone = normalizePhone(request.Phone);
            var hashedPassword = _cryptoHelper.HashPassword(request.Password);

            var admin = await _adminRepository.GetByPhoneAsync(normalizedPhone);
            if (admin == null
                || admin.Password != hashedPassword)
                throw new UnauthorizedAccessException();

            return new LoginResponseDto
            {
                Token = _cryptoHelper.GenerateAuthToken(admin.Id, Guid.NewGuid(), UserRoles.Admin, _configuration["Security:Secret"]),
                Role = UserRoles.Admin
            };

            throw new UnauthorizedAccessException();
        }

        private long normalizePhone(string phone)
        {
            try
            {
                if (phone.StartsWith("7") || phone.StartsWith("8"))
                    phone = phone.Substring(1);
                else if (phone.StartsWith("+7"))
                    phone = phone.Substring(2);

                return long.Parse(
                    phone.Trim()
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace("(", "")
                    .Replace(")", ""));
            }
            catch
            {
                throw new FormatException("Incorrect phone format");
            }
        }

        private UserRoles getHighestUserRole(IEnumerable<UserRoles> userRoles)
        {
            if (userRoles.Contains(UserRoles.Commitee))
                return UserRoles.Commitee;
            if (userRoles.Contains(UserRoles.Parent))
                return UserRoles.Parent;

            throw new UnauthorizedAccessException();
        }

        private UserRoles getHighestAdminRole(IEnumerable<UserRoles> userRoles)
        {
            if (userRoles.Contains(UserRoles.Admin))
                return UserRoles.Admin;

            throw new UnauthorizedAccessException();
        }

        private readonly List<UserRoles> LoginUserRoles = new List<UserRoles> { UserRoles.Commitee, UserRoles.Parent };
    }
}
