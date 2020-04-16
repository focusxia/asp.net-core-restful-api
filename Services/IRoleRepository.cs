using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Services
{
    public interface IRoleRepository
    {
        Task<RoleModelSelect> Get(Guid roleId);
        Task<bool> Insert(RoleModelAdd role);
        Task<bool> Update(RoleModelUpdate roleModel);
        Task<bool> Delete(Guid roleId);
    }
}
