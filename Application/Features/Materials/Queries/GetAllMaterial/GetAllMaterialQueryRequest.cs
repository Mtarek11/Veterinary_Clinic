using Application.Abstract.Paginate;
using MediatR;

namespace Application.Features.Materials.Queries.GetAllMateria;

public record GetAllMaterialQueryRequest(Pagination pagination, string? Name = null) : IRequest<List<GetAllMaterialQueryResponse>>
{
    public GetAllMaterialQueryRequest() : this(new Pagination()) { }
}


