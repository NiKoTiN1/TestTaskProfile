﻿using AutoMapper;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.ViewModels.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, options => options.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.Email, options => options.MapFrom(x => x.Email));
            
            CreateMap<User, GetUserModel>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Email, options => options.MapFrom(x => x.Email));
        }
    }
}
