using Garten.Database.Entities;
using System;
using System.Threading.Tasks;

namespace Garten.Database.Repositories.Interfaces
{
    public interface IUserSessionRepository
    {
        Task<UserSession> Create(UserSession entity, Guid userId);
    }
}
