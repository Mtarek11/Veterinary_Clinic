using Application.Features.Users.Commands.LoginUser;
using AutoMapper;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Login
            CreateMap <LoginUserCommandResponse, TokenDto>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.Token!.AccessToken))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.Token!.RefreshToken))
            .ForMember(dest => dest.Expiration, opt => opt.MapFrom(src => src.Token!.Expiration))
            .ReverseMap();
        }
    }
}
