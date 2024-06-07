using MediatR;

namespace Application.Features.Materials.Queries.GetByIdMaterial
{
    public record GetByIdMaterialQueryRequest(string Id) : IRequest<GetByIdMaterialQueryResponse> { }
}


