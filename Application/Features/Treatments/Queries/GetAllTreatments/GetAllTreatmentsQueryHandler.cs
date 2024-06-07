using Application.Features.Customers.Queries.GetAllArticle;
using Application.Repositories.Customers;
using Application.Repositories.Treatments;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Queries.GetAllTreatments
{
    public class GetAllTreatmentsQueryHandler(ITreatmentQueryRepository treatmentQueryRepository, IMapper mapper) : IRequestHandler<GetAllTreatmentsQueryRequest, List<GetAllTreatmentsQueryResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ITreatmentQueryRepository _treatmentQueryRepository = treatmentQueryRepository;
        public async Task<List<GetAllTreatmentsQueryResponse>> Handle(GetAllTreatmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var treatments = await _treatmentQueryRepository.GetAll<object>(null, false, null).ToListAsync();
            var mapped = _mapper.Map<List<GetAllTreatmentsQueryResponse>>(treatments);
            return mapped;
        }
    }
}
