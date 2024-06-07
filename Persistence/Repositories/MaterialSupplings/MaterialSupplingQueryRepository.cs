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
    public class MaterialSupplingQueryRepository(Context context) : QueryRepository<MaterialSuppling>(context), IMaterialSupplingQueryRepository
    {
    }
}
