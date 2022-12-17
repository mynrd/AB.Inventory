using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AB.Inventory.Core
{
    public class RepositoryQuery<T> where T : class
    {
        private List<Expression<Func<T, bool>>> _filter;
        private Func<IQueryable<T>, IOrderedQueryable<T>> _orderByQuerable;

        protected IQueryable<T> _query { get; }

        public RepositoryQuery(IQueryable<T> query)
        {
            _query = query;
            _filter = new List<Expression<Func<T, bool>>>();
        }

        public RepositoryQuery<T> Filter(Expression<Func<T, bool>> filter)
        {
            _filter.Add(filter);
            return this;
        }

        public IQueryable<T> Get()
        {
            var query = _query.AsQueryable();

            if (_filter != null)
                _filter.ForEach(f =>
                {
                    query = query.Where(f);
                });

            if (_orderByQuerable != null)
                query = _orderByQuerable(query);

            return query;
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Get().ToListAsync(cancellationToken);
        }

        public async Task<PagingResult<T>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = Get();
            var count = query.Count();

            var result = new PagingResult<T>(count, page, pageSize);

            if (result.TotalPage > 0 && result.TotalPage < page)
            {
                return await GetPageAsync(1, pageSize, cancellationToken);
            }

            if (pageSize > 0)
            {
                query = query.Skip(page).Take(pageSize);
            }

            var data = await query.ToListAsync(cancellationToken);
            result.Items = data;

            return result;
        }

        public RepositoryQuery<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            _orderByQuerable = orderBy;
            return this;
        }
    }
}