using Application.Exceptions;
using Application.Features.Materials.Commands.RemoveMaterial;
using Application.Features.MaterialSupplings.Commands.RemoveMaterialSuppling;
using Application.Repositories.MaterialSupplings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Commands.RemoveMaterialSuppling
{
    public class RemoveMaterialSupplingCommandHandler(IMaterialSupplingQueryRepository materialSupplingQueryRepository, IMaterialSupplingCommandRepository materialSupplingCommandRepository)
        : IRequestHandler<RemoveMaterialSupplingCommandRequest, RemoveMaterialSupplingCommandResponse>
    {
        private readonly IMaterialSupplingCommandRepository _materialSupplingCommandRepository = materialSupplingCommandRepository; 
        private readonly IMaterialSupplingQueryRepository _materialSupplingQueryRepository = materialSupplingQueryRepository;
        public async Task<RemoveMaterialSupplingCommandResponse> Handle(RemoveMaterialSupplingCommandRequest request, CancellationToken cancellationToken)
        {
            var materialSuppling = await _materialSupplingQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Material not found");
            await _materialSupplingCommandRepository.RemoveAsync(materialSuppling);
            var response = new RemoveMaterialSupplingCommandResponse
            {
                Message = "Material suppling removed successfully."
            };
            return response;
        }
    }
}
