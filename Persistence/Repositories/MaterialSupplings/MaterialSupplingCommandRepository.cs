using Application.Repositories.Materials;
using Application.Repositories.MaterialSupplings;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.MaterialSupplings
{
    public class MaterialSupplingCommandRepository(Context context) : CommandRepository<MaterialSuppling>(context), IMaterialSupplingCommandRepository
    {
    }
}
