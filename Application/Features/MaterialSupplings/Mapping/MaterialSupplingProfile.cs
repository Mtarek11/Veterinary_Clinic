using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Materials.Commands.CreateMaterial;
using Application.Features.Materials.Queries.GetAllMateria;
using Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling;
using Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Mapping
{
    public class MaterialSupplingProfile : Profile
    {
        public MaterialSupplingProfile()
        {
            //Create Mapping
            CreateMap<CreateMaterialSupplingCommendRequest, MaterialSuppling>();
            //GetAll Mapping
            CreateMap<MaterialSuppling, GetAllMaterialSupplingQueryResponse>();
        }
    }
}
