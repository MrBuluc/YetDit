using System.Linq.Expressions;
using YetDit.Domain.Common;

namespace YetDit.Application.Repositories
{
    public interface IReadRepository<T, TId> : IRepository<T, TId> where T : EntityBase<TId>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> metot);
        Task<T> GetAsync(Expression<Func<T, bool>> metot);
        Task<T> GetByIdAsync(string id);
    }
}
