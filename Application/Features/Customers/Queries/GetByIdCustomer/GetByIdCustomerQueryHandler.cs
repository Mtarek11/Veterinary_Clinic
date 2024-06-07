using Application.Exceptions;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Repositories.Customers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Serilog;
using System.Linq.Expressions;

namespace Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetByIdCustomerQueryHandler(ICustomerQueryRepository customerQueryRepository, IMapper mapper) : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository = customerQueryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerQueryRepository.GetByIdAsync(request.Id, false) ?? throw new NotFoundEntityException("Customer not found");
            var mapped = _mapper.Map<GetByIdCustomerQueryResponse>(customer);
            return mapped;
        }
    }
}



