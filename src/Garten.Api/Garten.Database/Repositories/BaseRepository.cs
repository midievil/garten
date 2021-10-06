using Garten.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garten.Database.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository(GartenContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public IQueryable<TEntity> GetByIds(IEnumerable<Guid> ids)
        {
            return _context.Set<TEntity>().Where(p => ids.Contains(p.Id));
        }

        public async Task<TEntity> Create(TEntity entity, Guid creatorId)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.CreatorId = creatorId;
            entity.DateCreated = DateTimeOffset.UtcNow;
            entity.IsActive = true;
            var result = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return;
            entity.IsDeleted = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public DbSet<TEntity> Entities => _context.Set<TEntity>();
    }
}
