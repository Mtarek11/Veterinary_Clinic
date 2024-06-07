using Application.Exceptions;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Repositories.Customers;
using Application.Repositories.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.UpdateTreatment
{
    public class UpdateTreatmentCommandHandler(ITreatmentCommandRepository treatmentCommandRepository, ITreatmentQueryRepository treatmentQueryRepository
        ) : IRequestHandler<UpdateTreatmentCommandRequest, UpdateTreatmentCommandResponse>
    {
        private readonly ITreatmentCommandRepository _treatmentCommandRepository = treatmentCommandRepository;
        private readonly ITreatmentQueryRepository _treatmentQueryRepository = treatmentQueryRepository;

        public async Task<UpdateTreatmentCommandResponse> Handle(UpdateTreatmentCommandRequest request, CancellationToken cancellationToken)
        {
            var treatment = await _treatmentQueryRepository.GetByIdAsync(request.Id!) ?? throw new NotFoundEntityException("Treatment not found");
            treatment.Name = request.Name;
            treatment.Coast = request.Coast;

            await _treatmentCommandRepository.UpdateAsync(treatment);
            var response = new UpdateTreatmentCommandResponse
            {
                Message = "Treatment updated successfully."
            };
            return response;
        }
    }
}
