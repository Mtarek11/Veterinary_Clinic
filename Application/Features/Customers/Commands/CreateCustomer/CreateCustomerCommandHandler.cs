using Application.Repositories.Customers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper) : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository = customerCommandRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            await _customerCommandRepository.AddAsync(customer);
            var response = new CreateCustomerCommandResponse
            {
                Message = "Customer created successfully."
            };
            return response;
        }
    }
}