using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using YetDit.Application.Repositories;
using YetDit.Domain.Common;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories
{
    public class WriteRepository<T, TId> : IWriteRepository<T, TId> where T : EntityBase<TId>
    {
        private readonly YetDitDbContext _context;

        public WriteRepository(YetDitDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<TId> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.Entity.Id;
        }

        public async Task<bool> RemoveAsync(TId id)
        {
            var entity = await Table.FindAsync(id);

            if (entity != null)
            {
                var entityEntry = Table.Remove(entity);
                return entityEntry.State == EntityState.Deleted;
            }

            return false;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
