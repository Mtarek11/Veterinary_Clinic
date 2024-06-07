using Application.Repositories.BaseRepositories;
using Domain.Comman;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BaseRepositories
{
    public class QueryRepository<TEntity>(Context context) : IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly Context _context = context;

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>>? filter = null, bool tracking = true, Expression<Func<TEntity, TKey>> ? orderBy = null,
            Expression<Func<TEntity, TEntity>>? projection = null)
        {
            var query = Table.AsQueryable();
            if (filter is not null) query = query.Where(filter);
            if (projection is not null) query = query.Select(projection);
            if (orderBy is not null) query = query.OrderByDescending(orderBy);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
#pragma warning disable CS8603 // Possible null reference return.
            return await query.FirstOrDefaultAsync(filter);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true, Expression<Func<TEntity, TEntity>>? projection = null)
        {
            var query = Table.AsQueryable();
            if (projection is not null) query = query.Select(projection);
            if (!tracking) query = query.AsNoTracking();
#pragma warning disable CS8603 // Possible null reference return.
            return await query.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
