using MediatR;

namespace Application.Features.Customers.Queries.GetByIdCustomer
{
    public record GetByIdCustomerQueryRequest(string Id) : IRequest<GetByIdCustomerQueryResponse> { }
}


