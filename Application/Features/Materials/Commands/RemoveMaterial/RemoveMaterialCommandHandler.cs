using Application.Exceptions;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Repositories.Customers;
using Application.Repositories.Materials;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.RemoveMaterial
{
    public class RemoveMaterialCommandHandlerr(IMaterialCommandRepository materialCommandRepository, IMaterialQueryRepository materialQueryRepository)
        : IRequestHandler<RemoveMaterialCommandRequest, RemoveMaterialCommandResponse>
    {
        private readonly IMaterialQueryRepository _materialQueryRepository = materialQueryRepository;
        private readonly IMaterialCommandRepository _materialCommandRepository = materialCommandRepository;

        public async Task<RemoveMaterialCommandResponse> Handle(RemoveMaterialCommandRequest request, CancellationToken cancellationToken)
        {
            var material = await _materialQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Material not found");
            material.IsDeleted = true;

            await _materialCommandRepository.UpdateAsync(material);
            var response = new RemoveMaterialCommandResponse
            {
                Message = "Material removed successfully."
            };
            return response;
        }
    }
}