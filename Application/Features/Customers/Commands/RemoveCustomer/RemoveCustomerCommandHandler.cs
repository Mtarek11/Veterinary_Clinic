using Application.Exceptions;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Repositories.Customers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.RemoveCustomer
{
    public class RemoveCustomerCommandHandlerr(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository)
        : IRequestHandler<RemoveCustomerCommandRequest, RemoveCustomerCommandResponse>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository = customerQueryRepository;
        private readonly ICustomerCommandRepository _customerCommandRepository = customerCommandRepository;

        public async Task<RemoveCustomerCommandResponse> Handle(RemoveCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Customer not found");
            customer.IsDeleted = true;

            await _customerCommandRepository.UpdateAsync(customer);
            var response = new RemoveCustomerCommandResponse
            {
                Message = "Customer removed successfully."
            };
            return response;
        }
    }
}