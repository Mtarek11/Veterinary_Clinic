using Application.Exceptions;
using Application.Features.Materials.Commands.RemoveMaterial;
using Application.Repositories.Customers;
using Application.Repositories.Materials;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler(IMaterialCommandRepository materialCommandRepository, IMaterialQueryRepository materialQueryRepository)
        : IRequestHandler<UpdateMaterialCommandRequest, UpdateMaterialCommandResponse>
    {
        private readonly IMaterialQueryRepository _materialQueryRepository = materialQueryRepository;
        private readonly IMaterialCommandRepository _materialCommandRepository = materialCommandRepository;

        public async Task<UpdateMaterialCommandResponse> Handle(UpdateMaterialCommandRequest request, CancellationToken cancellationToken)
        {
            var material = await _materialQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Material not found");
            material.Name = request.Name;

            await _materialCommandRepository.UpdateAsync(material);
            var response = new UpdateMaterialCommandResponse
            {
                Message = "Material updated successfully."
            };
            return response;
        }
    }
}
