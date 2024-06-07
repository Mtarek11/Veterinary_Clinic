using Application.Abstract.Paginate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling
{
    public record GetAllMaterialSupplingQueryRequest(Pagination pagination, string? MaterialName = null, DateTime? SupplyDate = null ) : IRequest<List<GetAllMaterialSupplingQueryResponse>>
    {
        public GetAllMaterialSupplingQueryRequest() : this (new Pagination()) { }
    }
}
