using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using DotnetRestFulWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRestFulWebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionRepository _permissionRepository;
        public UserController(IUserRepository userRepository, IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _permissionRepository = permissionRepository ?? throw new ArgumentException(nameof(permissionRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _userRepository.Get(userId);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]UserModelAdd user)
        {
            var result = await _userRepository.Insert(user);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] UserModelUpdate user)
        {
            var result = await _userRepository.Update(user);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid roleId)
        {
            var result = await _userRepository.Delete(roleId);

            return Ok(result);
        }
    }
}