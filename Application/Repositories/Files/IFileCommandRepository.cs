using Application.Repositories.BaseRepositories;
using Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Files
{
    public interface IFileCommandRepository : ICommandRepository<BaseFile>
    {
    }
}
