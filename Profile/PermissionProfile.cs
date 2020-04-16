using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Helper
{
    public class PermissionProfile: Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionModelAdd, Permission>();
            CreateMap<Permission, Permission>();

            CreateMap<PermissionModelSelect, Permission>();
            CreateMap<Permission, PermissionModelSelect>();
        }
    }
}
