using Application.Repositories.Treatments;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.CreateTratement
{
    public class CreateTreatmentCommandHandler(ITreatmentCommandRepository treatmentCommandRepository, IMapper mapper) : IRequestHandler<CreateTreatmentCommandRequest, CreateTreatmentCommandResponse>
    {
        private readonly ITreatmentCommandRepository _treatmentCommandRepository = treatmentCommandRepository; 
        private readonly IMapper _mapper = mapper;
        public async Task<CreateTreatmentCommandResponse> Handle(CreateTreatmentCommandRequest request, CancellationToken cancellationToken)
        {
            var treatment = _mapper.Map<Treatment>(request);
            await _treatmentCommandRepository.AddAsync(treatment);
            var response = new CreateTreatmentCommandResponse()
            {
                Message = "Treatment created successfully."
            };
            return response;
        }
    }
}
