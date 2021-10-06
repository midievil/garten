using Garten.Database.Entities;
using Garten.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GartenContext context) : base(context)
        {
        }

        public async Task<User> GetByPhoneAsync(long phone)
        {
            return await Entities.FirstOrDefaultAsync(user => user.Phone == phone);
        }

        public IQueryable<User> List()
        {
            return Entities;
        }
    }
}
