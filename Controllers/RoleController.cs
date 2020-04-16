using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using DotnetRestFulWebApi.Services;

namespace DotnetRestFulWebApi.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public RoleController(IMapper mapper, IRoleRepository userRepository)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _roleRepository = userRepository ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetRole(Guid roleId)
        {
            var result = await _roleRepository.Get(roleId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody]RoleModelAdd role)
        {
            var result = await _roleRepository.Insert(role);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRole(RoleModelUpdate roleModel)
        {
            var result = await _roleRepository.Update(roleModel);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(Guid roleId)
        {
            var result = await _roleRepository.Delete(roleId);

            return Ok(result);
        }
    }
}