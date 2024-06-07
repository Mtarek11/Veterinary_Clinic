using Application.Repositories.BaseRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Admins
{
    public interface IAdminQueryRepository : IQueryRepository<Admin>
    {
        Task<Admin?> GetAdminByEmailAsync(string email);
        Task<Admin?> GetAdminByRefreshTokenAsync(string refreshToken);
    }
}
