using Application.Repositories.Admins;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Admins
{
    public class AdminCommandRepository(Context context) : CommandRepository<Admin>(context), IAdminCommandRepository
    {
       
    }
}
