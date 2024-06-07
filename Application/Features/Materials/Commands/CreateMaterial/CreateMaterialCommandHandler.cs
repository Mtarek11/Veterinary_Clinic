using Application.Features.Materials.Commands.CreateMaterial;
using Application.Repositories.Materials;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler(IMaterialCommandRepository materialCommandRepository, IMapper mapper) : IRequestHandler<CreateMaterialCommandRequest, CreateMaterialCommandResponse>
    {
        private readonly IMaterialCommandRepository _materialCommandRepository = materialCommandRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateMaterialCommandResponse> Handle(CreateMaterialCommandRequest request, CancellationToken cancellationToken)
        {
            var material = _mapper.Map<Material>(request);
            await _materialCommandRepository.AddAsync(material);
            var response = new CreateMaterialCommandResponse
            {
                Message = "Material created successfully."
            };
            return response;
        }
    }
}