using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Helper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleModelAdd>();
            CreateMap<RoleModelAdd, Role>();

            CreateMap<Role, RoleModelSelect>();
            CreateMap<RoleModelSelect, Role>();
        }
    }
}
