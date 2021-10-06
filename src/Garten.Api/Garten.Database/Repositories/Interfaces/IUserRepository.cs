using Garten.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByPhoneAsync(long phone);
        Task<User> Create(User user, Guid creatorId);
        Task<User> Update(User user);
        IQueryable<User> List();
    }
}
