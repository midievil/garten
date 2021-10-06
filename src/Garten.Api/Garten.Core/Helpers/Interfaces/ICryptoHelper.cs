using Garten.Common.Models.User;
using System;

namespace Garten.Helpers.Interfaces
{
    /// <summary>
    /// Cryptography helper
    /// </summary>
    public interface ICryptoHelper
    {
        /// <summary>
        /// Creates password hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>Hashed password</returns>
        public string HashPassword(string password);

        /// <summary>
        /// Generates authorization token
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="sessionId">User session Id</param>
        /// <param name="userRoles"></param>
        /// <param name="secretKey">Server key</param>
        /// <returns>Authorization token</returns>
        public string GenerateAuthToken(Guid? userId, Guid sessionId, UserRoles userRoles, string secretKey);
    }
}
