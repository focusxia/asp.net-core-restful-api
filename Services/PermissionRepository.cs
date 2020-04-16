using AutoMapper;
using DotnetRestFulWebApi.Entities;
using DotnetRestFulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Services
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IMapper _mapper;
        private readonly FutrueContext _context;
        public PermissionRepository(IMapper mapper, FutrueContext context)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _context = context ?? throw new ArgumentException(nameof(mapper));
        }
        public async Task<bool> Insert(PermissionModelAdd permissionModelAdd)
        {
            var permissionEntity = _mapper.Map<Permission>(permissionModelAdd);
            _context.Permission.Add(permissionEntity);
            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }
    }
}
