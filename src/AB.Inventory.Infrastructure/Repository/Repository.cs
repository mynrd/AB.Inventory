using AB.Inventory.Application.Interfaces;
using AB.Inventory.Core;
using AB.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AB.Inventory.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ABInventoryContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ABInventoryContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual RepositoryQuery<TEntity> CreateQuery()
        {
            return new RepositoryQuery<TEntity>(DbSet.AsQueryable());
        }
    }
}