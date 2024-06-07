using Application.Abstract.Paginate;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPaginationService<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> ListPagination(IList<TEntity> entities, Pagination pagination);
        IQueryable<TEntity> QueryablePagination(IQueryable<TEntity> entities, Pagination pagination);
        IEnumerable<TEntity> EnumerablePagination(IEnumerable<TEntity> entities, Pagination pagination);
    }
}
