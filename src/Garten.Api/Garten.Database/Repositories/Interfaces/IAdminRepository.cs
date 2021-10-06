using Garten.Database.Entities;
using System.Threading.Tasks;

namespace Garten.Database.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> GetByPhoneAsync(long phone);
    }
}
