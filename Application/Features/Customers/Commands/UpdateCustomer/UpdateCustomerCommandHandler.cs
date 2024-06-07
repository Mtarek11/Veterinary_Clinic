using Application.Exceptions;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Repositories.Customers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository)
        : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository = customerQueryRepository;
        private readonly ICustomerCommandRepository _customerCommandRepository = customerCommandRepository;

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Customer not found");
            customer.PhoneNumber = request.PhoneNumber;
            customer.DateOfBirth = request.DateOfBirth;
            customer.Name = request.Name;

            await _customerCommandRepository.UpdateAsync(customer);
            var response = new UpdateCustomerCommandResponse
            {
                Message = "Customer updated successfully."
            };
            return response;
        }
    }
}
