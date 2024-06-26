﻿using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITokenHandlerService
    {
        TokenDto CreateAccessToken(int minute, Admin admin);
        string GenerateRefreshToken();
    }
}
