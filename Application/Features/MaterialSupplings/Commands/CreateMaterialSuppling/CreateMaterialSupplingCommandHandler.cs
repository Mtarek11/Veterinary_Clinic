using Application.Repositories.MaterialSupplings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling
{
    public class CreateMaterialSupplingCommandHandler(IMaterialSupplingCommandRepository materialSupplingCommandRepository, IMapper mapper) : IRequestHandler<CreateMaterialSupplingCommendRequest, CreateMaterialSupplingCommandResponse>
    {
        private readonly IMaterialSupplingCommandRepository _materialSupplingCommandRepository = materialSupplingCommandRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CreateMaterialSupplingCommandResponse> Handle(CreateMaterialSupplingCommendRequest request, CancellationToken cancellationToken)
        {
            var materialSuppling = _mapper.Map<MaterialSuppling>(request);
            await _materialSupplingCommandRepository.AddAsync(materialSuppling);
            var response = new CreateMaterialSupplingCommandResponse
            {
                Message = "Material suppling created successfully."
            };
            return response;
        }
    }
}
