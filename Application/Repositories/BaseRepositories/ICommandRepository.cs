using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.BaseRepositories
{
    public interface ICommandRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<TEntity> RemoveByIdAsync(string id);
        Task<bool> RemoveRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
