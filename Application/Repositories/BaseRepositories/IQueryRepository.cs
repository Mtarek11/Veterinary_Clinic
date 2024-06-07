using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.BaseRepositories
{
    public interface IQueryRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>>? filter = null, bool tracking = true, Expression<Func<TEntity, TKey>>? orderBy = null,
             Expression<Func<TEntity, TEntity>>? projection = null);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetByIdAsync(string id, bool tracking = true, Expression<Func<TEntity, TEntity>>? projection = null);
    }
}
