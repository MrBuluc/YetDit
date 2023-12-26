using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            // Önce Id'yi TId türüne çevir
            TId entityId = ConvertId(id);

            // Ardından eşleşen varlığı getir
            return await Table.FirstOrDefaultAsync(data => EqualityComparer<TId>.Default.Equals(data.Id, entityId));
        }

        // Id'yi TId türüne çeviren yardımcı metot
        private TId ConvertId(string id)
        {
            // Bu örnek sadece Guid tipini destekliyor, diğer türler için genişletilebilir
            return (TId)(object)Guid.Parse(id);
        }
    }
}
