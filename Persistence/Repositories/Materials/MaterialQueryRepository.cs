using Application.Repositories.Materials;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Materials
{
    public class MaterialQueryRepository(Context context) : QueryRepository<Material>(context), IMaterialQueryRepository
    {
    }
}
