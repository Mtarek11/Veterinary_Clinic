using Application.Features.Customers.Queries.GetAllArticle;
using Application.Repositories.Customers;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Features.Customers.Queries.GetAllCustomer;

public class GetAllCustomerQueryHandler(ICustomerQueryRepository customerQueryRepository, IMapper mapper, IPaginationService<Customer> paginationService)
    : IRequestHandler<GetAllCustomerQueryRequest, List<GetAllCustomerQueryResponse>>
{
    private readonly ICustomerQueryRepository _customerQueryRepository = customerQueryRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IPaginationService<Customer> _paginationService = paginationService;
     
    public async Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Customer, bool>>? filter = c => c.IsDeleted == false;
        if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.PhoneNumber))
        {
            filter = c => c.Name.Contains(request.Name) && c.PhoneNumber.Contains(request.PhoneNumber) && !c.IsDeleted;
        }
        else if (!string.IsNullOrEmpty(request.Name))
        {
            filter = c => c.Name.Contains(request.Name) && !c.IsDeleted;
        }
        else if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            filter = c => c.PhoneNumber.Contains(request.PhoneNumber) && !c.IsDeleted;
        }
        var customers = _customerQueryRepository.GetAll<object>(filter, false, null);
        var pagination = _paginationService.QueryablePagination(customers, request.pagination);
        List<Customer> paginatedCustomers = await pagination.ToListAsync(cancellationToken: cancellationToken);
        var mapped = _mapper.Map<List<GetAllCustomerQueryResponse>>(paginatedCustomers);
        return mapped;
    }
}



