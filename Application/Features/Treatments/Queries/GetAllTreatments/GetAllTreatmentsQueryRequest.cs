using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Queries.GetAllTreatments
{
    public record GetAllTreatmentsQueryRequest : IRequest<List<GetAllTreatmentsQueryResponse>>
    {
    }
}
