using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.MaterialSupplings.Projections;
using Application.Repositories.Customers;
using Application.Repositories.MaterialSupplings;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling
{
    public class GetAllMaterialSupplingQueryHandler(IMaterialSupplingQueryRepository materialSupplingQueryRepository, IMapper mapper, IPaginationService<MaterialSuppling> paginationService)
        : IRequestHandler<GetAllMaterialSupplingQueryRequest, List<GetAllMaterialSupplingQueryResponse>>
    {
        private readonly IMaterialSupplingQueryRepository _materialSupplingQueryRepository = materialSupplingQueryRepository; 
        private readonly IMapper _mapper = mapper;
        private readonly IPaginationService<MaterialSuppling> _paginationService = paginationService;

        public async Task<List<GetAllMaterialSupplingQueryResponse>> Handle(GetAllMaterialSupplingQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<MaterialSuppling, bool>>? filter = null;
            Expression<Func<MaterialSuppling, DateTime>>? orderBy = m => m.SupplyDate;
            Expression<Func<MaterialSuppling, MaterialSuppling>> projection = GetAllMaterialSupplingProjection.ToGetAllMaterialSupplingProjection();
            if (!string.IsNullOrEmpty(request.MaterialName) && request.SupplyDate != null)
            {
                filter = m => m.Material.Name.Contains(request.MaterialName) && m.SupplyDate >= request.SupplyDate;
            }
            else if (!string.IsNullOrEmpty(request.MaterialName))
            {
                filter = m => m.Material.Name.Contains(request.MaterialName);
            }
            else if (request.SupplyDate != null)
            {
                filter = m => m.SupplyDate >= request.SupplyDate;
            }
            var materialSupplings = _materialSupplingQueryRepository.GetAll(filter, false, orderBy, projection);
            var pagination = _paginationService.QueryablePagination(materialSupplings, request.pagination);
            List<MaterialSuppling> paginatedMaterialSupplings = await pagination.ToListAsync(cancellationToken: cancellationToken);
            var mapped = _mapper.Map<List<GetAllMaterialSupplingQueryResponse>>(paginatedMaterialSupplings);
            return mapped;
        }
    }
}
