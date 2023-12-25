using Microsoft.EntityFrameworkCore;
using YetDit.Domain.Common;

namespace YetDit.Application.Repositories
{
    public interface IRepository<T, TKey> where T : EntityBase<TKey>
    {
        DbSet<T> Table { get; }
    }
}
