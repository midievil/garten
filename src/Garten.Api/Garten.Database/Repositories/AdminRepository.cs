using Garten.Database.Entities;
using Garten.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Garten.Database.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(GartenContext context) : base(context)
        {
        }

        public async Task<Admin> GetByPhoneAsync(long phone)
        {
            return await Entities.FirstOrDefaultAsync(user => user.Phone == phone);
        }
    }
}