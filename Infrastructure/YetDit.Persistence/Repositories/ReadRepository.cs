using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YetDit.Application.Repositories;
using YetDit.Domain.Common;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories
{
    public class ReadRepository<T, TId> : IReadRepository<T, TId> where T : EntityBase<TId>
    {
        private readonly YetDitDbContext _context;

        public ReadRepository(YetDitDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> metot)
        {
            return Table.Where(metot).AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> metot)
        {
            return await Table.FirstOrDefaultAsync(metot);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            // Ardından eşleşen varlığı getir
            return await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }
    }
}
