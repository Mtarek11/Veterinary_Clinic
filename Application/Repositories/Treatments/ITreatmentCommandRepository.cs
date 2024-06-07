using Application.Repositories.BaseRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Treatments
{
    public interface ITreatmentCommandRepository : ICommandRepository<Treatment>
    {
    }
}
