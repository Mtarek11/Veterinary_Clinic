using Domain.Comman;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.BaseRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
