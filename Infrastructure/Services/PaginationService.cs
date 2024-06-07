using Application.Abstract.Paginate;
using Application.Services;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PaginationService<TEntity> : IPaginationService<TEntity> where TEntity : BaseEntity
    {
        public IList<TEntity> ListPagination(IList<TEntity> entities, Pagination pagination)
            => entities.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToList();

        public IQueryable<TEntity> QueryablePagination(IQueryable<TEntity> entities, Pagination pagination)
            => entities.Skip(pagination.Page * pagination.Size).Take(pagination.Size);

        public IEnumerable<TEntity> EnumerablePagination(IEnumerable<TEntity> entities, Pagination pagination)
            => entities.Skip(pagination.Page * pagination.Size).Take(pagination.Size);
    }
}
