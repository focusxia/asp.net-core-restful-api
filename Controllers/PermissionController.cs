using System;
using System.Threading.Tasks;
using DotnetRestFulWebApi.Models;
using DotnetRestFulWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRestFulWebApi.Controllers
{
    [ApiController]
    [Route("api/permission")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentException(nameof(permissionRepository));
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission([FromBody]PermissionModelAdd permissionModelAdd)
        {
            var result = await _permissionRepository.Insert(permissionModelAdd);

            return Ok(result);
        }
    }
}
