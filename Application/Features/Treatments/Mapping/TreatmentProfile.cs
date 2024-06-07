using Application.Features.Treatments.Commands.CreateTratement;
using Application.Features.Treatments.Queries.GetAllTreatments;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Mapping
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile() 
        {
            //Create mapping
            CreateMap<CreateTreatmentCommandRequest, Treatment>();

            //Get all mapping
            CreateMap<Treatment, GetAllTreatmentsQueryResponse>();
        }
    }
}
