using Application.Repositories.BaseRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Materials
{
    public interface IMaterialCommandRepository : ICommandRepository<Material>
    {
    }
}
