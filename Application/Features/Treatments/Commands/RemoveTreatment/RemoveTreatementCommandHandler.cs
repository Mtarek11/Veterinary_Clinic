using Application.Exceptions;
using Application.Repositories.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.RemoveTreatment
{
    public class RemoveTreatementCommandHandler(ITreatmentCommandRepository treatmentCommandRepository, ITreatmentQueryRepository treatmentQueryRepository
        ) : IRequestHandler<RemoveTreatmentCommandRequest, RemoveTreatmentCommandResponse>
    {
        private readonly ITreatmentCommandRepository _treatmentCommandRepository = treatmentCommandRepository;
        private readonly ITreatmentQueryRepository _treatmentQueryRepository = treatmentQueryRepository;
        public async Task<RemoveTreatmentCommandResponse> Handle(RemoveTreatmentCommandRequest request, CancellationToken cancellationToken)
        {
            var treatment = await _treatmentQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Treatment not found");
            treatment.IsDeleted = true;

            await _treatmentCommandRepository.UpdateAsync(treatment);
            var response = new RemoveTreatmentCommandResponse()
            {
                Message = "Treatment removed successfully."
            };
            return response;
        }
    }
}
