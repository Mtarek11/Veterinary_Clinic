
using Application.Repositories.BaseRepositories;
using Domain.Comman;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BaseRepositories
{
    public class CommandRepository<TEntity>(Context context) : ICommandRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly Context _context = context;

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            Table.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> RemoveByIdAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(x => x.Id ==id);
            await RemoveAsync(entity!);
            await SaveChangesAsync();
            return entity!;
        }

        public async Task<bool> RemoveRangeAsync(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
    }
}
