using Application.Abstract.Paginate;
using MediatR;

namespace Application.Features.Customers.Queries.GetAllArticle;

public record GetAllCustomerQueryRequest(Pagination pagination, string? Name = null, string? PhoneNumber = null) : IRequest<List<GetAllCustomerQueryResponse>>
{
    public GetAllCustomerQueryRequest() : this (new Pagination()) { }
}


