using Application.Exceptions;
using Application.Repositories.Admins;
using Application.Services;
using Domain.Entities;
using Persistence.Repositories.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UserService(IAdminCommandRepository adminCommandRepository) : IUserService
    {
        private readonly IAdminCommandRepository _adminCommandRepository = adminCommandRepository;

        public async Task InsertRefreshToken(string refreshToken, Admin admin, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (admin != null)
            {
                admin.RefreshToken = refreshToken;
                admin.RefreshTokenEndDate = accessTokenDate.AddMonths(addOnAccessTokenDate);
                await _adminCommandRepository.UpdateAsync(admin);
            }
            else
                throw new NotFoundUserException();
        }
    }
}
