using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Customers.Commands.CreateCustomer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Customers.Queries.GetByIdCustomer;

namespace Application.Features.Customers.Mapping
{
    public class CustomerProfile : Profile
    { 
        public CustomerProfile()
        {
            //Create Mapping
            CreateMap<CreateCustomerCommandRequest, Customer>();
            //GetAll Mapping
            CreateMap<Customer, GetAllCustomerQueryResponse>();
            //GetById Mapping
            CreateMap<Customer, GetByIdCustomerQueryResponse>();
        }
    }
}
