using Application.Repositories.Admins;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Admins
{
    public class AdminQueryRepository(Context context) : QueryRepository<Admin>(context), IAdminQueryRepository
    {
        public async Task<Admin?> GetAdminByEmailAsync(string email)
        {
            return await GetByFilterAsync(u => u.Email == email);
        }

        public async Task<Admin?> GetAdminByRefreshTokenAsync(string refreshToken)
        {
            return await GetByFilterAsync(u => u.RefreshToken == refreshToken);
        }
    }
}
