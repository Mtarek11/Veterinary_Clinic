using Application.Exceptions;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Materials.Projections;
using Application.Repositories.Customers;
using Application.Repositories.Materials;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Serilog;
using System.Linq.Expressions;

namespace Application.Features.Materials.Queries.GetByIdMaterial
{
    public class GetByIdMaterialQueryHandler(IMaterialQueryRepository materialQueryRepository, IMapper mapper) : IRequestHandler<GetByIdMaterialQueryRequest, GetByIdMaterialQueryResponse>
    {
        private readonly IMaterialQueryRepository _materialQueryRepository = materialQueryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetByIdMaterialQueryResponse> Handle(GetByIdMaterialQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Material, Material>> projection = GetByIdMaterialProjection.ToGetByIdMaterialrojection();
            var material = await _materialQueryRepository.GetByIdAsync(request.Id, false, projection) ?? throw new NotFoundEntityException("Material not found");
            var mapped = _mapper.Map<GetByIdMaterialQueryResponse>(material);
            return mapped; 
        }
    }
}



