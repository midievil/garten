using Garten.Database.Entities;
using Garten.Database.Repositories.Interfaces;

namespace Garten.Database.Repositories
{
    public class UserSessionRepository : BaseRepository<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(GartenContext context) : base(context)
        {
        }
    }
}
