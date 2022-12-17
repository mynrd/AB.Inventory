using AB.Inventory.Core;
using AB.Inventory.Domain.Entities;
using System.Linq.Expressions;

namespace AB.Inventory.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        RepositoryQuery<TEntity> CreateQuery();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}