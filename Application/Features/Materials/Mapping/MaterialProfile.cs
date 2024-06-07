using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Customers.Commands.CreateCustomer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Materials.Commands.CreateMaterial;
using Application.Features.Materials.Queries.GetAllMateria;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Materials.Queries.GetByIdMaterial;

namespace Application.Features.Materials.Mapping
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile() 
        {
            //Create Mapping
            CreateMap<CreateMaterialCommandRequest, Material>();
            //GetAll Mapping
            CreateMap<Material, GetAllMaterialQueryResponse>();
            //GetById Mapping
            CreateMap<Material, GetByIdMaterialQueryResponse>();
        }
    }
}
