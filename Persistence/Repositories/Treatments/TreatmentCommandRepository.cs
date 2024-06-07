using Application.Repositories.Treatments;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Treatments
{
    public class TreatmentCommandRepository(Context context) : CommandRepository<Treatment>(context), ITreatmentCommandRepository
    {
    }
}
