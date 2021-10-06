using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Database.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetByIds(IEnumerable<Guid> ids);
        Task<TEntity> Create(TEntity entity, Guid creatorId);
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id);
    }
}
