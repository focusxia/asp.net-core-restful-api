using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Services
{
    public interface IUserRepository
    {
        Task<UserModelSelect> Get(Guid userId);
        Task<bool> Insert(UserModelAdd user);
        Task<bool> Update(UserModelUpdate user);
        Task<bool> Delete(Guid userId);
    }
}
