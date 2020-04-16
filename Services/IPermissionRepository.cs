using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Services
{
    public interface IPermissionRepository
    {
        Task<bool> Insert(PermissionModelAdd permissionModelAdd);
    }
}
