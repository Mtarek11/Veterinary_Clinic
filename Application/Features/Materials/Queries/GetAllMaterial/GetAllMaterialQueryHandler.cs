using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Materials.Queries.GetAllMateria;
using Application.Repositories.Customers;
using Application.Repositories.Materials;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Features.Materials.Queries.GetAllMaterial;

public class GetAllMaterialQueryHandler(IMaterialQueryRepository materialQueryRepository, IMapper mapper, IPaginationService<Material> paginationService)
    : IRequestHandler<GetAllMaterialQueryRequest, List<GetAllMaterialQueryResponse>>
{
    private readonly IMaterialQueryRepository _materialQueryRepository = materialQueryRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IPaginationService<Material> _paginationService = paginationService;

    public async Task<List<GetAllMaterialQueryResponse>> Handle(GetAllMaterialQueryRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Material, bool>>? filter = m => !m.IsDeleted;

        if (!string.IsNullOrEmpty(request.Name))
        {
            filter = m => m.Name.Contains(request.Name) && !m.IsDeleted;
        }
        var materials = _materialQueryRepository.GetAll<object>(filter, false);
        var pagination = _paginationService.QueryablePagination(materials, request.pagination);
        List<Material> paginatedCustomers = await pagination.ToListAsync(cancellationToken: cancellationToken);
        var mapped = _mapper.Map<List<GetAllMaterialQueryResponse>>(paginatedCustomers);
        return mapped;
    }
}



