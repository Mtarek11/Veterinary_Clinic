using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task InsertRefreshToken(string refreshToken, Admin admin, DateTime addOnAccessTokenDate, int refreshTokenLifeTime);
    }
}
