using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Helper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModelAdd>();
            CreateMap<UserModelAdd, User>();

            CreateMap<UserModelSelect, User>();
            CreateMap<User, UserModelSelect>();
        }
    }
}
