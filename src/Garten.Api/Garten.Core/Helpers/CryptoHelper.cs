using Garten.Common.Models.User;
using Garten.Helpers.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Garten.Helpers
{
    /// <inheritdoc/>
    public class CryptoHelper : ICryptoHelper
    {
        /// <inheritdoc/>
        public string HashPassword(string password)
        {
            var sha512 = SHA512.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha512.ComputeHash(bytes);

            return string.Concat(hash.Select(p => p.ToString("x2")));
        }

        /// <inheritdoc/>
        public string GenerateAuthToken(Guid? userId, Guid sessionId, UserRoles userRoles, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Sid, sessionId.ToString()),
                    new Claim(ClaimTypes.Role, Enum.GetName(userRoles))
                };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}